using Microsoft.EntityFrameworkCore;
using _01_NguyenTuanMinh_4003867.Models;

namespace _01_NguyenTuanMinh_4003867.Data
{
    /// <summary>
    /// Repository for LopQuanLy (Class) operations
    /// </summary>
    public class LopQuanLyRepository
    {
        public List<LopQuanLy> GetAll()
        {
            using var db = DatabaseHelper.GetDb();
            return db.LopQuanLys
                .OrderBy(l => l.LqLma)
                .ToList();
        }

        public LopQuanLy? GetById(string lqLma)
        {
            using var db = DatabaseHelper.GetDb();
            return db.LopQuanLys
                .FirstOrDefault(l => l.LqLma == lqLma);
        }

        public List<LopQuanLy> Search(string keyword)
        {
            using var db = DatabaseHelper.GetDb();
            return db.LopQuanLys
                .Where(l => l.LqLma.Contains(keyword) ||
                            l.LqTen.Contains(keyword) ||
                            l.LqKhoaHoc.ToString().Contains(keyword))
                .OrderBy(l => l.LqLma)
                .ToList();
        }

        public bool Add(LopQuanLy lopQuanLy)
        {
            using var db = DatabaseHelper.GetDb();
            db.LopQuanLys.Add(lopQuanLy);
            return db.SaveChanges() > 0;
        }

        public bool Update(LopQuanLy lopQuanLy)
        {
            using var db = DatabaseHelper.GetDb();
            db.LopQuanLys.Update(lopQuanLy);
            return db.SaveChanges() > 0;
        }

        public bool Delete(string lqLma)
        {
            using var db = DatabaseHelper.GetDb();

            // Check if there are students in this class
            var studentCount = db.SinhViens.Count(s => s.LqLma == lqLma);
            if (studentCount > 0)
            {
                return false; // Cannot delete class with students
            }

            return db.LopQuanLys
                .Where(l => l.LqLma == lqLma)
                .ExecuteDelete() > 0;
        }

        public bool Exists(string lqLma)
        {
            using var db = DatabaseHelper.GetDb();
            return db.LopQuanLys
                .Any(l => l.LqLma == lqLma);
        }

        public int GetStudentCount(string lqLma)
        {
            using var db = DatabaseHelper.GetDb();
            return db.SinhViens
                .Count(s => s.LqLma == lqLma);
        }

        public List<string> GetAllIds()
        {
            using var db = DatabaseHelper.GetDb();
            return db.LopQuanLys
                .Select(l => l.LqLma)
                .ToList();
        }

        public int GetCount()
        {
            using var db = DatabaseHelper.GetDb();
            return db.LopQuanLys.Count();
        }

        public List<LopQuanLy> GetPage(int pageIndex, int pageSize)
        {
            using var db = DatabaseHelper.GetDb();
            return db.LopQuanLys
                .OrderBy(l => l.LqLma)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
