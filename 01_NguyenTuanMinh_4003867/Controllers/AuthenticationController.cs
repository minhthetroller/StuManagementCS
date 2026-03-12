using _01_NguyenTuanMinh_4003867.Data;
using _01_NguyenTuanMinh_4003867.Models;

namespace _01_NguyenTuanMinh_4003867.Controllers
{
    /// <summary>
    /// Controller for authentication and session management
    /// </summary>
    public class AuthenticationController
    {
        private readonly TaiKhoanRepository _repository;
        private static TaiKhoan? _currentUser;
        private static NhomQuyen? _currentUserRole;

        public AuthenticationController()
        {
            _repository = new TaiKhoanRepository();
        }

        public (bool success, string message) Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return (false, "Tên đăng nhập không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return (false, "Mật khẩu không được để trống!");
            }

            var user = _repository.ValidateLogin(username.Trim(), password.Trim());

            if (user != null)
            {
                _currentUser = user;
                _currentUserRole = _repository.GetNhomQuyen(user.NqMa);
                return (true, "Đăng nhập thành công!");
            }

            return (false, "Đăng nhập thất bại!");
        }

        public void Logout()
        {
            _currentUser = null;
            _currentUserRole = null;
        }

        public static bool IsAuthenticated()
        {
            return _currentUser != null;
        }

        public static TaiKhoan? GetCurrentUser()
        {
            return _currentUser;
        }

        public static NhomQuyen? GetCurrentUserRole()
        {
            return _currentUserRole;
        }

        public static string GetCurrentUsername()
        {
            return _currentUser?.TkTaiKhoan ?? string.Empty;
        }

        public static string GetCurrentUserRoleName()
        {
            return _currentUserRole?.NqTen ?? string.Empty;
        }
    }
}
