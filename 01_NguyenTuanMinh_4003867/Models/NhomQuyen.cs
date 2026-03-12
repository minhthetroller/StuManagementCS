using LinqToDB.Mapping;

namespace _01_NguyenTuanMinh_4003867.Models
{
    /// <summary>
    /// Model representing a department (Nhóm quyền)
    /// </summary>
    [Table("tbl_nhomquyen")]
    public class NhomQuyen
    {
        [Column("nqma"), PrimaryKey, Identity]
        public int NqMa { get; set; }

        [Column("nqten")]
        public string NqTen { get; set; } = string.Empty;

        [Column("nqmota")]
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
