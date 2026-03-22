using Microsoft.EntityFrameworkCore;
using _01_NguyenTuanMinh_4003867.Models;

namespace _01_NguyenTuanMinh_4003867.Data
{
    /// <summary>
    /// Repository for SinhVien (Student) operations
    /// </summary>
    public class SinhVienRepository
    {
        public List<SinhVien> GetAll()
        {
            using var db = DatabaseHelper.GetDb();
            return db.SinhViens
                .OrderBy(s => s.SvMa)
                .ToList();
        }

        public SinhVien? GetById(string svMa)
        {
            using var db = DatabaseHelper.GetDb();
            return db.SinhViens
                .FirstOrDefault(s => s.SvMa == svMa);
        }

        public List<SinhVien> Search(string keyword, string? lqLma = null)
        {
            using var db = DatabaseHelper.GetDb();

            var query = db.SinhViens
                .Where(s => s.SvMa.Contains(keyword) ||
                            s.SvTen.Contains(keyword) ||
                            (s.SvQueQuan != null && s.SvQueQuan.Contains(keyword)));

            if (!string.IsNullOrEmpty(lqLma))
            {
                query = query.Where(s => s.LqLma == lqLma);
            }

            return query
                .OrderBy(s => s.SvMa)
                .ToList();
        }

        public bool Add(SinhVien sinhVien)
        {
            using var db = DatabaseHelper.GetDb();
            db.SinhViens.Add(sinhVien);
            return db.SaveChanges() > 0;
        }

        public bool Update(SinhVien sinhVien)
        {
            using var db = DatabaseHelper.GetDb();
            db.SinhViens.Update(sinhVien);
            return db.SaveChanges() > 0;
        }

        public bool Delete(string svMa)
        {
            using var db = DatabaseHelper.GetDb();
            return db.SinhViens
                .Where(s => s.SvMa == svMa)
                .ExecuteDelete() > 0;
        }

        public bool Exists(string svMa)
        {
            using var db = DatabaseHelper.GetDb();
            return db.SinhViens
                .Any(s => s.SvMa == svMa);
        }

        public List<string> GetAllIds()
        {
            using var db = DatabaseHelper.GetDb();
            return db.SinhViens
                .Select(s => s.SvMa)
                .ToList();
        }

        public int GetCount()
        {
            using var db = DatabaseHelper.GetDb();
            return db.SinhViens.Count();
        }

        public List<SinhVien> GetPage(int pageIndex, int pageSize)
        {
            using var db = DatabaseHelper.GetDb();
            return db.SinhViens
                .OrderBy(s => s.SvMa)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
