using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_NguyenTuanMinh_4003867.Models
{
    /// <summary>
    /// Model representing a permission group (Nhóm quyền)
    /// </summary>
    [Table("tbl_nhomquyen")]
    public class NhomQuyen
    {
        [Key]
        [Column("nqma")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NqMa { get; set; }

        [Required]
        [Column("nqten")]
        [MaxLength(50)]
        public string NqTen { get; set; } = string.Empty;

        [Column("nqmota", TypeName = "nvarchar(max)")]
        public string? NqMoTa { get; set; }

        public NhomQuyen() { }

        public NhomQuyen(int nqMa, string nqTen, string? nqMoTa)
        {
            NqMa = nqMa;
            NqTen = nqTen;
            NqMoTa = nqMoTa;
        }
    }
}
