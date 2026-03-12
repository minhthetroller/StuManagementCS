using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider.SqlServer;
using _01_NguyenTuanMinh_4003867.Models;
using System.Text;
using System.Text.Json;

namespace _01_NguyenTuanMinh_4003867.Data
{
    /// <summary>
    /// Database connection and initialization handler for SQL Server
    /// </summary>
    public class DatabaseHelper
    {
        private static string _connectionString = string.Empty;
        private static string _serverAddress = "172.20.10.2";
        private static string _username = "sa";
        private static string _password = "Tam979hn@";
        private static string _databaseName = "StudentManagement";

        public static void Initialize()
        {
            // Ensure UTF-8 encoding for Vietnamese characters
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // Load connection settings from config file
            LoadSettings();

            // Build connection string for SQL Server
            _connectionString = BuildConnectionString(_databaseName);

            // Create database if not exists
            CreateDatabaseIfNotExists();

            // Create tables
            CreateTables();
        }

        private static void LoadSettings()
        {
            try
            {
                string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string configPath = Path.Combine(appDirectory, "dbsettings.json");

                if (File.Exists(configPath))
                {
                    string json = File.ReadAllText(configPath, Encoding.UTF8);
                    var settings = JsonSerializer.Deserialize<JsonElement>(json);

                    if (settings.TryGetProperty("ServerAddress", out var server))
                        _serverAddress = server.GetString() ?? _serverAddress;
                    if (settings.TryGetProperty("Username", out var user))
                        _username = user.GetString() ?? _username;
                    if (settings.TryGetProperty("Password", out var pass))
                        _password = pass.GetString() ?? _password;
                    if (settings.TryGetProperty("DatabaseName", out var db))
                        _databaseName = db.GetString() ?? _databaseName;
                }
            }
            catch
            {
                // Use default values if config file cannot be read
            }
        }

        private static string BuildConnectionString(string catalog)
        {
            return $"Data Source={_serverAddress};Initial Catalog={catalog};" +
                   $"User ID={_username};Password={_password};" +
                   $"TrustServerCertificate=True;Encrypt=False";
        }

        private static void CreateDatabaseIfNotExists()
        {
            // Connection to master database via LinqToDB DataConnection
            var masterConnStr = BuildConnectionString("master");
            using var masterDb = new DataConnection(CreateDataOptions(masterConnStr));

            // Check if database exists
            var result = masterDb.Execute<int?>(
                $"SELECT database_id FROM sys.databases WHERE name = '{_databaseName}'");

            if (result == null)
            {
                // Create database
                masterDb.Execute($"CREATE DATABASE [{_databaseName}]");
            }
        }

        private static DataOptions CreateDataOptions(string connectionString)
        {
            return new DataOptions().UseConnectionString(
                SqlServerTools.GetDataProvider(SqlServerVersion.v2019, SqlServerProvider.MicrosoftDataSqlClient),
                connectionString);
        }

        public static StudentManagementDb GetDb()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                Initialize();
            }
            return new StudentManagementDb(CreateDataOptions(_connectionString));
        }

        private static void CreateTables()
        {
            using var db = GetDb();

            // Read SQL script from file
            string sqlScript = GetDatabaseScript();

            // Execute script in batches (split by GO)
            var batches = sqlScript.Split(new[] { "\r\nGO\r\n", "\nGO\n", "\r\nGO", "GO\r\n" }, 
                StringSplitOptions.RemoveEmptyEntries);

            foreach (var batch in batches)
            {
                if (!string.IsNullOrWhiteSpace(batch))
                {
                    db.Execute(batch);
                }
            }
        }

        private static string GetDatabaseScript()
        {
            try
            {
                // Try to read from Data folder
                string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string scriptPath = Path.Combine(appDirectory, "Data", "InitializeDatabase.sql");

                if (File.Exists(scriptPath))
                {
                    return File.ReadAllText(scriptPath, Encoding.UTF8);
                }

                // Fallback to embedded script if file not found
                return GetFallbackScript();
            }
            catch
            {
                // Return embedded script as fallback
                return GetFallbackScript();
            }
        }

        private static string GetFallbackScript()
        {
            return @"
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'tbl_nhomquyen')
                BEGIN
                    CREATE TABLE tbl_nhomquyen (
                        nqma INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
                        nqten NVARCHAR(50) NOT NULL,
                        nqmota TEXT NULL
                    );
                END

                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'tbl_taikhoan')
                BEGIN
                    CREATE TABLE tbl_taikhoan (
                        tktaikhoan NVARCHAR(30) PRIMARY KEY NOT NULL,
                        tkmatkhau NVARCHAR(30) NOT NULL,
                        nqma INT NOT NULL,
                        CONSTRAINT FK_taikhoan_nhomquyen FOREIGN KEY (nqma) REFERENCES tbl_nhomquyen(nqma)
                    );
                END

                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'tbl_lopquanly')
                BEGIN
                    CREATE TABLE tbl_lopquanly (
                        lqlma NCHAR(10) PRIMARY KEY NOT NULL,
                        lqten NVARCHAR(50) NOT NULL,
                        lqkhoahoc INT NOT NULL
                    );
                END

                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'tbl_sinhvien')
                BEGIN
                    CREATE TABLE tbl_sinhvien (
                        svma NCHAR(10) PRIMARY KEY NOT NULL,
                        svten NVARCHAR(50) NOT NULL,
                        svngaysinh DATE NULL,
                        svgioitinh TINYINT NULL,
                        svquequan NVARCHAR(50) NULL,
                        lqlma NCHAR(10) NOT NULL,
                        CONSTRAINT FK_sinhvien_lopquanly FOREIGN KEY (lqlma) REFERENCES tbl_lopquanly(lqlma)
                    );
                END
            ";
        }

        public static void InsertSampleData()
        {
            using var db = GetDb();

            // Check if data already exists
            var count = db.NhomQuyens.Count();
            if (count > 0) return; // Data already exists

            using var transaction = db.BeginTransaction();

            try
            {
                // Insert permissions with specific identity values
                var permissions = new[]
                {
                    (1, "Admin", "Quản trị viên - Toàn quyền hệ thống"),
                    (2, "Employee", "Nhân viên - Quản lý sinh viên và lớp học"),
                    (3, "User", "Người dùng - Chỉ xem thông tin")
                };

                db.Execute("SET IDENTITY_INSERT tbl_nhomquyen ON");
                foreach (var (ma, ten, mota) in permissions)
                {
                    db.GetTable<NhomQuyen>()
                        .Value(p => p.NqMa, ma)
                        .Value(p => p.NqTen, ten)
                        .Value(p => p.NqMoTa, mota)
                        .Insert();
                }
                db.Execute("SET IDENTITY_INSERT tbl_nhomquyen OFF");

                // Insert accounts
                var accounts = new[]
                {
                    ("admin", "123456", 1),
                    ("employee", "123456", 2),
                    ("user", "123456", 3)
                };

                foreach (var (tk, mk, nq) in accounts)
                {
                    db.Insert(new TaiKhoan(tk, mk, nq));
                }

                // Insert classes
                var classes = new[]
                {
                    ("CNTT2023A", "Công nghệ thông tin 2023A", 2023),
                    ("CNTT2023B", "Công nghệ thông tin 2023B", 2023),
                    ("CNTT2024A", "Công nghệ thông tin 2024A", 2024),
                    ("KTPM2023A", "Kỹ thuật phần mềm 2023A", 2023),
                    ("KTPM2024A", "Kỹ thuật phần mềm 2024A", 2024),
                    ("KHMT2023A", "Khoa học máy tính 2023A", 2023),
                    ("KHMT2024A", "Khoa học máy tính 2024A", 2024),
                    ("HTTT2023A", "Hệ thống thông tin 2023A", 2023)
                };

                foreach (var (ma, ten, khoa) in classes)
                {
                    db.Insert(new LopQuanLy(ma, ten, khoa));
                }

                // Insert students
                var students = new[]
                {
                    ("SV2023001", "Nguyễn Văn Anh", "2005-03-15", 1, "Hà Nội", "CNTT2023A"),
                    ("SV2023002", "Trần Thị Bảo", "2005-07-22", 0, "Hồ Chí Minh", "CNTT2023A"),
                    ("SV2023003", "Lê Minh Châu", "2005-01-10", 0, "Đà Nẵng", "CNTT2023A"),
                    ("SV2023004", "Phạm Quốc Dũng", "2005-11-05", 1, "Hải Phòng", "CNTT2023B"),
                    ("SV2023005", "Hoàng Thị Em", "2005-09-18", 0, "Cần Thơ", "CNTT2023B"),
                    ("SV2023006", "Võ Văn Phúc", "2005-04-25", 1, "Huế", "CNTT2023B"),
                    ("SV2024001", "Đặng Thị Giang", "2006-02-14", 0, "Nghệ An", "CNTT2024A"),
                    ("SV2024002", "Bùi Văn Hùng", "2006-06-30", 1, "Thanh Hóa", "CNTT2024A"),
                    ("SV2024003", "Ngô Thị Lan", "2006-08-12", 0, "Bình Dương", "CNTT2024A"),
                    ("SV2023007", "Lý Văn Kiên", "2005-12-20", 1, "Quảng Ninh", "KTPM2023A"),
                    ("SV2023008", "Mai Thị Linh", "2005-05-17", 0, "Nam Định", "KTPM2023A"),
                    ("SV2023009", "Đỗ Văn Mạnh", "2005-10-08", 1, "Hà Tĩnh", "KTPM2023A"),
                    ("SV2024004", "Trương Thị Nga", "2006-03-22", 0, "Vĩnh Phúc", "KTPM2024A"),
                    ("SV2024005", "Phan Văn Ổn", "2006-07-15", 1, "Bắc Ninh", "KTPM2024A"),
                    ("SV2023010", "Dương Thị Phương", "2005-04-11", 0, "Thái Bình", "KHMT2023A"),
                    ("SV2023011", "Tạ Văn Quang", "2005-09-28", 1, "Ninh Bình", "KHMT2023A"),
                    ("SV2024006", "Hồ Thị Rạng", "2006-01-19", 0, "Lào Cai", "KHMT2024A"),
                    ("SV2024007", "Trịnh Văn Sơn", "2006-11-25", 1, "Điện Biên", "KHMT2024A"),
                    ("SV2023012", "Lương Thị Tâm", "2005-06-07", 0, "Quảng Bình", "HTTT2023A"),
                    ("SV2023013", "Vương Văn Uy", "2005-08-14", 1, "Quảng Trị", "HTTT2023A")
                };

                foreach (var (ma, ten, ngaysinh, gioitinh, quequan, lop) in students)
                {
                    db.Insert(new SinhVien(ma, ten, DateTime.Parse(ngaysinh), gioitinh == 1, quequan, lop));
                }

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public static string GetDatabasePath()
        {
            return $"Server: {_serverAddress}, Database: {_databaseName}";
        }
    }
}
