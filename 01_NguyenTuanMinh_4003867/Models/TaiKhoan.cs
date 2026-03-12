using LinqToDB.Mapping;

namespace _01_NguyenTuanMinh_4003867.Models
{
    /// <summary>
    /// Model representing an account (Tài khoản)
    /// </summary>
    [Table("tbl_taikhoan")]
    public class TaiKhoan
    {
        [Column("tktaikhoan"), PrimaryKey]
        public string TkTaiKhoan { get; set; } = string.Empty;

        [Column("tkmatkhau")]
        public string TkMatKhau { get; set; } = string.Empty;

        [Column("nqma")]
        public int NqMa { get; set; }

        public TaiKhoan() { }

        public TaiKhoan(string tkTaiKhoan, string tkMatKhau, int nqMa)
        {
            TkTaiKhoan = tkTaiKhoan;
            TkMatKhau = tkMatKhau;
            NqMa = nqMa;
        }
    }
}
