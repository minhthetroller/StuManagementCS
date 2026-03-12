using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_NguyenTuanMinh_4003867.Models
{
    /// <summary>
    /// Model representing a student (Sinh viên)
    /// </summary>
    [Table("tbl_sinhvien")]
    public class SinhVien
    {
        private string _svMa = string.Empty;
        private string _lqLma = string.Empty;

        [Key]
        [Column("svma", TypeName = "nchar(10)")]
        public string SvMa
        {
            get => _svMa;
            set => _svMa = value?.Trim() ?? string.Empty;
        }

        [Required]
        [Column("svten")]
        [MaxLength(50)]
        public string SvTen { get; set; } = string.Empty;

        [Column("svngaysinh", TypeName = "date")]
        public DateTime? SvNgaySinh { get; set; }

        [Column("svgioitinh")]
        public byte? SvGioiTinhDb { get; set; }

        [NotMapped]
        public bool? SvGioiTinh
        {
            get => SvGioiTinhDb.HasValue ? Convert.ToBoolean(SvGioiTinhDb.Value) : null;
            set => SvGioiTinhDb = value.HasValue ? (byte)(value.Value ? 1 : 0) : null;
        }

        [Column("svquequan")]
        [MaxLength(50)]
        public string? SvQueQuan { get; set; }

        [Column("lqlma", TypeName = "nchar(10)")]
        public string LqLma
        {
            get => _lqLma;
            set => _lqLma = value?.Trim() ?? string.Empty;
        }

        public SinhVien() { }

        public SinhVien(string svMa, string svTen, DateTime? svNgaySinh, bool? svGioiTinh, string? svQueQuan, string lqLma)
        {
            SvMa = svMa;
            SvTen = svTen;
            SvNgaySinh = svNgaySinh;
            SvGioiTinh = svGioiTinh;
            SvQueQuan = svQueQuan;
            LqLma = lqLma;
        }
    }
}
