using _01_NguyenTuanMinh_4003867.Models;

namespace _01_NguyenTuanMinh_4003867.Data
{
    /// <summary>
    /// Repository for TaiKhoan (Account) operations
    /// </summary>
    public class TaiKhoanRepository
    {
        public TaiKhoan? ValidateLogin(string username, string password)
        {
            using var db = DatabaseHelper.GetDb();

            return (from t in db.TaiKhoans
                    join n in db.NhomQuyens on t.NqMa equals n.NqMa
                    where t.TkTaiKhoan == username && t.TkMatKhau == password
                    select t).FirstOrDefault();
        }

        public NhomQuyen? GetNhomQuyen(int nqMa)
        {
            using var db = DatabaseHelper.GetDb();
            return db.NhomQuyens
                .FirstOrDefault(n => n.NqMa == nqMa);
        }
    }
}
