using Microsoft.EntityFrameworkCore;
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
        private static string _serverAddress = string.Empty;
        private static string _username = string.Empty;
        private static string _password = string.Empty;
        private static string _databaseName = string.Empty;

        public static void Initialize()
        {
            // Ensure UTF-8 encoding for Vietnamese characters
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // Load connection settings from config file
            LoadSettings();

            // Build connection string for SQL Server
            _connectionString = BuildConnectionString(_databaseName);

            // Create database and tables via EF Core
            using var db = GetDb();
            db.Database.EnsureCreated();
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

        private static DbContextOptions<StudentManagementDb> CreateDbOptions()
        {
            return new DbContextOptionsBuilder<StudentManagementDb>()
                .UseSqlServer(_connectionString)
                .Options;
        }

        public static StudentManagementDb GetDb()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                Initialize();
            }
            return new StudentManagementDb(CreateDbOptions());
        }

        public static void InsertSampleData()
        {
            using var db = GetDb();

            // Check if data already exists
            if (db.NhomQuyens.Any()) return;

            using var transaction = db.Database.BeginTransaction();

            try
            {
                // Insert permissions (identity auto-assigns 1, 2, 3)
                db.NhomQuyens.AddRange(
                    new NhomQuyen { NqTen = "Admin", NqMoTa = "Quản trị viên - Toàn quyền hệ thống" },
                    new NhomQuyen { NqTen = "Employee", NqMoTa = "Nhân viên - Quản lý sinh viên và lớp học" },
                    new NhomQuyen { NqTen = "User", NqMoTa = "Người dùng - Chỉ xem thông tin" }
                );
                db.SaveChanges();

                // Insert accounts
                db.TaiKhoans.AddRange(
                    new TaiKhoan("admin", "123456", 1),
                    new TaiKhoan("employee", "123456", 2),
                    new TaiKhoan("user", "123456", 3)
                );
                db.SaveChanges();

                // Insert classes
                db.LopQuanLys.AddRange(
                    new LopQuanLy("CNTT2023A", "Công nghệ thông tin 2023A", 2023),
                    new LopQuanLy("CNTT2023B", "Công nghệ thông tin 2023B", 2023),
                    new LopQuanLy("CNTT2024A", "Công nghệ thông tin 2024A", 2024),
                    new LopQuanLy("KTPM2023A", "Kỹ thuật phần mềm 2023A", 2023),
                    new LopQuanLy("KTPM2024A", "Kỹ thuật phần mềm 2024A", 2024),
                    new LopQuanLy("KHMT2023A", "Khoa học máy tính 2023A", 2023),
                    new LopQuanLy("KHMT2024A", "Khoa học máy tính 2024A", 2024),
                    new LopQuanLy("HTTT2023A", "Hệ thống thông tin 2023A", 2023)
                );
                db.SaveChanges();

                // Insert students
                db.SinhViens.AddRange(
                    new SinhVien("SV2023001", "Nguyễn Văn Anh", DateTime.Parse("2005-03-15"), true, "Hà Nội", "CNTT2023A"),
                    new SinhVien("SV2023002", "Trần Thị Bảo", DateTime.Parse("2005-07-22"), false, "Hồ Chí Minh", "CNTT2023A"),
                    new SinhVien("SV2023003", "Lê Minh Châu", DateTime.Parse("2005-01-10"), false, "Đà Nẵng", "CNTT2023A"),
                    new SinhVien("SV2023004", "Phạm Quốc Dũng", DateTime.Parse("2005-11-05"), true, "Hải Phòng", "CNTT2023B"),
                    new SinhVien("SV2023005", "Hoàng Thị Em", DateTime.Parse("2005-09-18"), false, "Cần Thơ", "CNTT2023B"),
                    new SinhVien("SV2023006", "Võ Văn Phúc", DateTime.Parse("2005-04-25"), true, "Huế", "CNTT2023B"),
                    new SinhVien("SV2024001", "Đặng Thị Giang", DateTime.Parse("2006-02-14"), false, "Nghệ An", "CNTT2024A"),
                    new SinhVien("SV2024002", "Bùi Văn Hùng", DateTime.Parse("2006-06-30"), true, "Thanh Hóa", "CNTT2024A"),
                    new SinhVien("SV2024003", "Ngô Thị Lan", DateTime.Parse("2006-08-12"), false, "Bình Dương", "CNTT2024A"),
                    new SinhVien("SV2023007", "Lý Văn Kiên", DateTime.Parse("2005-12-20"), true, "Quảng Ninh", "KTPM2023A"),
                    new SinhVien("SV2023008", "Mai Thị Linh", DateTime.Parse("2005-05-17"), false, "Nam Định", "KTPM2023A"),
                    new SinhVien("SV2023009", "Đỗ Văn Mạnh", DateTime.Parse("2005-10-08"), true, "Hà Tĩnh", "KTPM2023A"),
                    new SinhVien("SV2024004", "Trương Thị Nga", DateTime.Parse("2006-03-22"), false, "Vĩnh Phúc", "KTPM2024A"),
                    new SinhVien("SV2024005", "Phan Văn Ổn", DateTime.Parse("2006-07-15"), true, "Bắc Ninh", "KTPM2024A"),
                    new SinhVien("SV2023010", "Dương Thị Phương", DateTime.Parse("2005-04-11"), false, "Thái Bình", "KHMT2023A"),
                    new SinhVien("SV2023011", "Tạ Văn Quang", DateTime.Parse("2005-09-28"), true, "Ninh Bình", "KHMT2023A"),
                    new SinhVien("SV2024006", "Hồ Thị Rạng", DateTime.Parse("2006-01-19"), false, "Lào Cai", "KHMT2024A"),
                    new SinhVien("SV2024007", "Trịnh Văn Sơn", DateTime.Parse("2006-11-25"), true, "Điện Biên", "KHMT2024A"),
                    new SinhVien("SV2023012", "Lương Thị Tâm", DateTime.Parse("2005-06-07"), false, "Quảng Bình", "HTTT2023A"),
                    new SinhVien("SV2023013", "Vương Văn Uy", DateTime.Parse("2005-08-14"), true, "Quảng Trị", "HTTT2023A")
                );
                db.SaveChanges();

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
