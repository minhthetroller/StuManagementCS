using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_NguyenTuanMinh_4003867.Models
{
    /// <summary>
    /// Model representing an account (Tài khoản)
    /// </summary>
    [Table("tbl_taikhoan")]
    public class TaiKhoan
    {
        [Key]
        [Column("tktaikhoan")]
        [MaxLength(30)]
        public string TkTaiKhoan { get; set; } = string.Empty;

        [Required]
        [Column("tkmatkhau")]
        [MaxLength(30)]
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
