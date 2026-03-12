using Microsoft.EntityFrameworkCore;
using _01_NguyenTuanMinh_4003867.Models;

namespace _01_NguyenTuanMinh_4003867.Data
{
    /// <summary>
    /// Entity Framework Core DbContext for StudentManagement database
    /// </summary>
    public class StudentManagementDb : DbContext
    {
        public StudentManagementDb(DbContextOptions<StudentManagementDb> options)
            : base(options)
        {
        }

        public DbSet<NhomQuyen> NhomQuyens => Set<NhomQuyen>();
        public DbSet<TaiKhoan> TaiKhoans => Set<TaiKhoan>();
        public DbSet<LopQuanLy> LopQuanLys => Set<LopQuanLy>();
        public DbSet<SinhVien> SinhViens => Set<SinhVien>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasOne<NhomQuyen>()
                    .WithMany()
                    .HasForeignKey(t => t.NqMa)
                    .HasConstraintName("FK_taikhoan_nhomquyen");
            });

            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.HasOne<LopQuanLy>()
                    .WithMany()
                    .HasForeignKey(s => s.LqLma)
                    .HasConstraintName("FK_sinhvien_lopquanly");
            });
        }
    }
}
