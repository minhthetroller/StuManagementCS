using _01_NguyenTuanMinh_4003867.Data;
using _01_NguyenTuanMinh_4003867.Models;

namespace _01_NguyenTuanMinh_4003867.Controllers
{
    /// <summary>
    /// Controller for SinhVien (Student) business logic
    /// </summary>
    public class SinhVienController
    {
        private readonly SinhVienRepository _repository;
        private readonly LopQuanLyRepository _lopRepository;

        public SinhVienController()
        {
            _repository = new SinhVienRepository();
            _lopRepository = new LopQuanLyRepository();
        }

        public List<SinhVien> GetAllSinhViens()
        {
            return _repository.GetAll();
        }

        public SinhVien? GetSinhVienById(string svMa)
        {
            return _repository.GetById(svMa);
        }

        public List<SinhVien> SearchSinhViens(string keyword, string? lqLma = null)
        {
            return _repository.Search(keyword, lqLma);
        }

        public (bool success, string message) AddSinhVien(SinhVien sinhVien)
        {
            // Validate input
            var validationResult = ValidateSinhVien(sinhVien);
            if (!validationResult.isValid)
            {
                return (false, validationResult.message);
            }

            // Check if student already exists
            if (_repository.Exists(sinhVien.SvMa))
            {
                return (false, "Mã sinh viên đã tồn tại!");
            }

            // Check if class exists
            if (!_lopRepository.Exists(sinhVien.LqLma))
            {
                return (false, "Mã lớp không tồn tại!");
            }

            bool result = _repository.Add(sinhVien);
            return result
                ? (true, "Thêm sinh viên thành công!")
                : (false, "Không thể thêm sinh viên. Vui lòng thử lại!");
        }

        public (bool success, string message) UpdateSinhVien(SinhVien sinhVien)
        {
            // Validate input
            var validationResult = ValidateSinhVien(sinhVien);
            if (!validationResult.isValid)
            {
                return (false, validationResult.message);
            }

            // Check if student exists
            if (!_repository.Exists(sinhVien.SvMa))
            {
                return (false, "Sinh viên không tồn tại!");
            }

            // Check if class exists
            if (!_lopRepository.Exists(sinhVien.LqLma))
            {
                return (false, "Mã lớp không tồn tại!");
            }

            bool result = _repository.Update(sinhVien);
            return result
                ? (true, "Cập nhật sinh viên thành công!")
                : (false, "Không thể cập nhật sinh viên. Vui lòng thử lại!");
        }

        public (bool success, string message) DeleteSinhVien(string svMa)
        {
            if (string.IsNullOrWhiteSpace(svMa))
            {
                return (false, "Mã sinh viên không hợp lệ!");
            }

            if (!_repository.Exists(svMa))
            {
                return (false, "Sinh viên không tồn tại!");
            }

            bool result = _repository.Delete(svMa);
            return result
                ? (true, "Xóa sinh viên thành công!")
                : (false, "Không thể xóa sinh viên. Vui lòng thử lại!");
        }

        private (bool isValid, string message) ValidateSinhVien(SinhVien sinhVien)
        {
            if (string.IsNullOrWhiteSpace(sinhVien.SvMa))
            {
                return (false, "Mã sinh viên không được để trống!");
            }

            if (sinhVien.SvMa.Length > 10)
            {
                return (false, "Mã sinh viên không được vượt quá 10 ký tự!");
            }

            if (string.IsNullOrWhiteSpace(sinhVien.SvTen))
            {
                return (false, "Tên sinh viên không được để trống!");
            }

            if (sinhVien.SvTen.Length > 50)
            {
                return (false, "Tên sinh viên không được vượt quá 50 ký tự!");
            }

            if (sinhVien.SvNgaySinh.HasValue)
            {
                if (sinhVien.SvNgaySinh.Value > DateTime.Now)
                {
                    return (false, "Ngày sinh không được lớn hơn ngày hiện tại!");
                }

                var age = DateTime.Now.Year - sinhVien.SvNgaySinh.Value.Year;
                if (age < 15 || age > 100)
                {
                    return (false, "Tuổi sinh viên phải trong khoảng 15-100!");
                }
            }

            if (!string.IsNullOrWhiteSpace(sinhVien.SvQueQuan) && sinhVien.SvQueQuan.Length > 50)
            {
                return (false, "Quê quán không được vượt quá 50 ký tự!");
            }

            if (string.IsNullOrWhiteSpace(sinhVien.LqLma))
            {
                return (false, "Mã lớp không được để trống!");
            }

            if (sinhVien.LqLma.Length > 10)
            {
                return (false, "Mã lớp không được vượt quá 10 ký tự!");
            }

            return (true, string.Empty);
        }
    }
}
