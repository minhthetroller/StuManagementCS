using _01_NguyenTuanMinh_4003867.Data;
using _01_NguyenTuanMinh_4003867.Models;

namespace _01_NguyenTuanMinh_4003867.Controllers
{
    /// <summary>
    /// Controller for LopQuanLy (Class) business logic
    /// </summary>
    public class LopQuanLyController
    {
        private readonly LopQuanLyRepository _repository;

        public LopQuanLyController()
        {
            _repository = new LopQuanLyRepository();
        }

        public List<LopQuanLy> GetAllLopQuanLys()
        {
            return _repository.GetAll();
        }

        public LopQuanLy? GetLopQuanLyById(string lqLma)
        {
            return _repository.GetById(lqLma);
        }

        public List<LopQuanLy> SearchLopQuanLys(string keyword)
        {
            return _repository.Search(keyword);
        }

        public (bool success, string message) AddLopQuanLy(LopQuanLy lopQuanLy)
        {
            // Validate input
            var validationResult = ValidateLopQuanLy(lopQuanLy);
            if (!validationResult.isValid)
            {
                return (false, validationResult.message);
            }

            // Check if class already exists
            if (_repository.Exists(lopQuanLy.LqLma))
            {
                return (false, "Mã lớp đã tồn tại!");
            }

            bool result = _repository.Add(lopQuanLy);
            return result
                ? (true, "Thêm lớp thành công!")
                : (false, "Không thể thêm lớp. Vui lòng thử lại!");
        }

        public (bool success, string message) UpdateLopQuanLy(LopQuanLy lopQuanLy)
        {
            // Validate input
            var validationResult = ValidateLopQuanLy(lopQuanLy);
            if (!validationResult.isValid)
            {
                return (false, validationResult.message);
            }

            // Check if class exists
            if (!_repository.Exists(lopQuanLy.LqLma))
            {
                return (false, "Lớp không tồn tại!");
            }

            bool result = _repository.Update(lopQuanLy);
            return result
                ? (true, "Cập nhật lớp thành công!")
                : (false, "Không thể cập nhật lớp. Vui lòng thử lại!");
        }

        public (bool success, string message) DeleteLopQuanLy(string lqLma)
        {
            if (string.IsNullOrWhiteSpace(lqLma))
            {
                return (false, "Mã lớp không hợp lệ!");
            }

            if (!_repository.Exists(lqLma))
            {
                return (false, "Lớp không tồn tại!");
            }

            // Check if there are students in this class
            int studentCount = _repository.GetStudentCount(lqLma);
            if (studentCount > 0)
            {
                return (false, $"Không thể xóa lớp vì còn {studentCount} sinh viên!");
            }

            bool result = _repository.Delete(lqLma);
            return result
                ? (true, "Xóa lớp thành công!")
                : (false, "Không thể xóa lớp. Vui lòng thử lại!");
        }

        public int GetStudentCount(string lqLma)
        {
            return _repository.GetStudentCount(lqLma);
        }

        private (bool isValid, string message) ValidateLopQuanLy(LopQuanLy lopQuanLy)
        {
            if (string.IsNullOrWhiteSpace(lopQuanLy.LqLma))
            {
                return (false, "Mã lớp không được để trống!");
            }

            if (lopQuanLy.LqLma.Length > 10)
            {
                return (false, "Mã lớp không được vượt quá 10 ký tự!");
            }

            if (string.IsNullOrWhiteSpace(lopQuanLy.LqTen))
            {
                return (false, "Tên lớp không được để trống!");
            }

            if (lopQuanLy.LqTen.Length > 50)
            {
                return (false, "Tên lớp không được vượt quá 50 ký tự!");
            }

            if (lopQuanLy.LqKhoaHoc < 2000 || lopQuanLy.LqKhoaHoc > DateTime.Now.Year + 1)
            {
                return (false, $"Khóa học phải trong khoảng 2000-{DateTime.Now.Year + 1}!");
            }

            return (true, string.Empty);
        }
    }
}
