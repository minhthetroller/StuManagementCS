using LinqToDB;
using LinqToDB.Data;
using _01_NguyenTuanMinh_4003867.Models;

namespace _01_NguyenTuanMinh_4003867.Data
{
    /// <summary>
    /// LINQ to SQL DataConnection for StudentManagement database
    /// </summary>
    public class StudentManagementDb : DataConnection
    {
        public StudentManagementDb(DataOptions options)
            : base(options)
        {
        }

        public ITable<NhomQuyen> NhomQuyens => this.GetTable<NhomQuyen>();
        public ITable<TaiKhoan> TaiKhoans => this.GetTable<TaiKhoan>();
        public ITable<LopQuanLy> LopQuanLys => this.GetTable<LopQuanLy>();
        public ITable<SinhVien> SinhViens => this.GetTable<SinhVien>();
    }
}
