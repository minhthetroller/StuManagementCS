using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_NguyenTuanMinh_4003867.Models
{
    /// <summary>
    /// Model representing a class (Lớp quản lý)
    /// </summary>
    [Table("tbl_lopquanly")]
    public class LopQuanLy
    {
        private string _lqLma = string.Empty;

        [Key]
        [Column("lqlma", TypeName = "nchar(10)")]
        public string LqLma
        {
            get => _lqLma;
            set => _lqLma = value?.Trim() ?? string.Empty;
        }

        [Required]
        [Column("lqten")]
        [MaxLength(50)]
        public string LqTen { get; set; } = string.Empty;

        [Column("lqkhoahoc")]
        public int LqKhoaHoc { get; set; }

        public LopQuanLy() { }

        public LopQuanLy(string lqLma, string lqTen, int lqKhoaHoc)
        {
            LqLma = lqLma;
            LqTen = lqTen;
            LqKhoaHoc = lqKhoaHoc;
        }
    }
}
