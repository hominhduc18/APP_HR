using Microsoft.EntityFrameworkCore;
using ItoApp.Domain.Entities;

namespace ItoApp.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<User> Users => Set<User>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<OtpCode> OtpCodes => Set<OtpCode>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
        
        // Hospital Entities
        public DbSet<HospitalBranch> HospitalBranches => Set<HospitalBranch>();
        public DbSet<Specialty> Specialties => Set<Specialty>();
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<DoctorSchedule> DoctorSchedules => Set<DoctorSchedule>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        
        // HR Entities (Tiếng Việt)
        public DbSet<ChiNhanh> ChiNhanhs => Set<ChiNhanh>();
        public DbSet<KhoaPhong> KhoaPhongs => Set<KhoaPhong>();
        public DbSet<NhomNgheNghiep> NhomNgheNghieps => Set<NhomNgheNghiep>();
        public DbSet<ChucVu> ChucVus => Set<ChucVu>();
        public DbSet<NhanVien> NhanViens => Set<NhanVien>();
        public DbSet<HopDongLaoDong> HopDongLaoDongs => Set<HopDongLaoDong>();
        public DbSet<ChungChiHanhNghe> ChungChiHanhNghes => Set<ChungChiHanhNghe>();
        public DbSet<ChungChiDaoTao> ChungChiDaoTaos => Set<ChungChiDaoTao>();
        public DbSet<KyThuatChuyenMon> KyThuatChuyenMons => Set<KyThuatChuyenMon>();
        public DbSet<KyLuat> KyLuats => Set<KyLuat>();
        public DbSet<LichSuChinhSua> LichSuChinhSuas => Set<LichSuChinhSua>();
        public DbSet<Dm_LoaiDichVu> Dm_LoaiDichVus => Set<Dm_LoaiDichVu>();
        public DbSet<Dm_NhomDichVu> Dm_NhomDichVus => Set<Dm_NhomDichVu>();
        public DbSet<Dm_DichVu> Dm_DichVus => Set<Dm_DichVu>();
        public DbSet<STT> STTs => Set<STT>();
        public DbSet<BenhNhan> BenhNhans => Set<BenhNhan>();
        public DbSet<Dm_PhongBan> Dm_PhongBans => Set<Dm_PhongBan>();
        public DbSet<TaiKhoanBenhNhan> TaiKhoanBenhNhans => Set<TaiKhoanBenhNhan>();
        public DbSet<Log_OTP> Log_OTPs => Set<Log_OTP>();

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Domain.Common.BaseEvent>();
            
            base.OnModelCreating(modelBuilder);
            
            // User configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                
                entity.Property(e => e.Email)
                    .HasConversion(
                        v => v != null ? v.Value : null,
                        v => v != null ? Domain.ValueObjects.Email.Create(v) : null)
                    .IsRequired(false)
                    .HasMaxLength(100);
                
                entity.Property(e => e.PhoneNumber)
                    .HasConversion(
                        v => v != null ? v.Value : null,
                        v => v != null ? Domain.ValueObjects.PhoneNumber.Create(v) : null)
                    .IsRequired(false)
                    .HasMaxLength(20);
                
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(200);
                
                entity.HasIndex(e => e.Email).IsUnique().HasFilter("[Email] IS NOT NULL");
                entity.HasIndex(e => e.PhoneNumber).IsUnique().HasFilter("[PhoneNumber] IS NOT NULL");
                
                entity.Property(e => e.Status).HasConversion<string>().HasMaxLength(20);
                
                entity.HasOne(u => u.Patient).WithOne(p => p.User).HasForeignKey<Patient>(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
            });
            
            // HospitalBranch configuration
            modelBuilder.Entity<HospitalBranch>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Address).IsRequired().HasMaxLength(500);
                entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(20);
            });

            // Specialty configuration
            modelBuilder.Entity<Specialty>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(1000);
            });

            // Doctor configuration
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(50);
                
                entity.HasOne(d => d.Specialty)
                    .WithMany(s => s.Doctors)
                    .HasForeignKey(d => d.SpecialtyId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // DoctorSchedule configuration
            modelBuilder.Entity<DoctorSchedule>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Date).HasColumnType("date");
                
                entity.HasOne(ds => ds.Doctor)
                    .WithMany(d => d.Schedules)
                    .HasForeignKey(ds => ds.DoctorId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ds => ds.Branch)
                    .WithMany(b => b.Schedules)
                    .HasForeignKey(ds => ds.BranchId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Appointment configuration
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.AppointmentDate).HasColumnType("date");
                entity.Property(e => e.BookingCode).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Status).HasConversion<string>().HasMaxLength(20);

                entity.HasOne(a => a.Patient)
                    .WithMany()
                    .HasForeignKey(a => a.PatientId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.Doctor)
                    .WithMany(d => d.Appointments)
                    .HasForeignKey(a => a.DoctorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.Branch)
                    .WithMany(b => b.Appointments)
                    .HasForeignKey(a => a.BranchId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Keep existing Patient, OTP, RefreshToken configs simplified...
            // Patient configuration
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.DateOfBirth).HasColumnType("date");
            });

            modelBuilder.Entity<OtpCode>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Identifier).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Code).IsRequired().HasMaxLength(10);
                entity.Property(e => e.Type).HasConversion<string>();
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Token).IsRequired().HasMaxLength(500);
            });

            // Cấu hình các bảng Nhân sự (Tiếng Việt)
            modelBuilder.Entity<ChiNhanh>(entity =>
            {
                entity.ToTable("ChiNhanh");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id_ChiNhanh");
                entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").IsRequired().HasMaxLength(20);
                entity.Property(e => e.TenChiNhanh).HasColumnName("TenChiNhanh").IsRequired().HasMaxLength(200);
                entity.Property(e => e.DiaChi).HasColumnName("DiaChi").HasMaxLength(500);
                entity.Property(e => e.SoDienThoai).HasColumnName("SoDienThoai").HasMaxLength(20);
                entity.Property(e => e.MaSoThue).HasColumnName("MaSoThue").HasMaxLength(20);
                entity.Property(e => e.CreatedAt).HasColumnName("NgayTao");
                entity.Property(e => e.UpdatedAt).HasColumnName("NgayCapNhat");
            });

            modelBuilder.Entity<KhoaPhong>(entity =>
            {
                entity.ToTable("KhoaPhong");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id_KhoaPhong");
                entity.Property(e => e.TenKhoaPhong).HasColumnName("TenKhoaPhong").IsRequired().HasMaxLength(200);
                entity.Property(e => e.CreatedAt).HasColumnName("NgayTao");
                entity.Property(e => e.UpdatedAt).HasColumnName("NgayCapNhat");

                entity.HasOne(e => e.ChiNhanh).WithMany(b => b.KhoaPhongs).HasForeignKey(e => e.ChiNhanhId);
            });

            modelBuilder.Entity<NhomNgheNghiep>(entity =>
            {
                entity.ToTable("NhomNgheNghiep");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id_Nhom");
                entity.Property(e => e.TenNhom).HasColumnName("TenNhom").IsRequired().HasMaxLength(100);
                entity.Property(e => e.CreatedAt).HasColumnName("NgayTao");
            });

            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.ToTable("ChucVu");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id_ChucVu");
                entity.Property(e => e.TenChucVu).HasColumnName("TenChucVu").IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.ToTable("NhanVien");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id_NhanVien");
                entity.Property(e => e.MaNhanVien).HasColumnName("MaNhanVien").IsRequired().HasMaxLength(50);
                entity.Property(e => e.HoTen).HasColumnName("HoTen").IsRequired().HasMaxLength(200);
                entity.Property(e => e.NgaySinh).HasColumnName("NgaySinh");
                entity.Property(e => e.GioiTinh).HasColumnName("GioiTinh").HasMaxLength(10);
                entity.Property(e => e.SoDienThoai).HasColumnName("SoDienThoai").HasMaxLength(20);
                entity.Property(e => e.Email).HasColumnName("Email").HasMaxLength(100);
                entity.Property(e => e.TrangThai).HasColumnName("TrangThai").HasMaxLength(20);
                entity.Property(e => e.CreatedAt).HasColumnName("NgayTao");

                entity.HasOne(e => e.ChiNhanh).WithMany(c => c.NhanViens).HasForeignKey(e => e.ChiNhanhId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.KhoaPhong).WithMany(k => k.NhanViens).HasForeignKey(e => e.KhoaPhongId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.NhomNgheNghiep).WithMany(n => n.NhanViens).HasForeignKey(e => e.NhomNgheNghiepId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.ChucVu).WithMany(c => c.NhanViens).HasForeignKey(e => e.ChucVuId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<HopDongLaoDong>(entity =>
            {
                entity.ToTable("HopDongLaoDong");
                entity.Property(e => e.Id).HasColumnName("Id_HopDong");
                entity.Property(e => e.SoHopDong).HasColumnName("SoHopDong");
                entity.Property(e => e.NgayKy).HasColumnName("NgayKy");
                entity.Property(e => e.NgayHetHan).HasColumnName("NgayHetHan");

                entity.HasOne(e => e.NhanVien).WithMany(nv => nv.HopDongLaoDongs).HasForeignKey(e => e.NhanVienId);
            });

            modelBuilder.Entity<ChungChiHanhNghe>(entity =>
            {
                entity.ToTable("ChungChiHanhNghe");
                entity.Property(e => e.Id).HasColumnName("Id_ChungChi");
                entity.Property(e => e.SoChungChi).HasColumnName("SoChungChi");
                entity.Property(e => e.NgayCap).HasColumnName("NgayCap");
                entity.Property(e => e.NgayHetHan).HasColumnName("NgayHetHan");
                entity.HasOne(e => e.NhanVien).WithMany(nv => nv.ChungChiHanhNghes).HasForeignKey(e => e.NhanVienId);
            });

            modelBuilder.Entity<ChungChiDaoTao>(entity =>
            {
                entity.ToTable("ChungChiDaoTao");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id_ChungChiDaoTao");
                entity.HasOne(e => e.NhanVien).WithMany(nv => nv.ChungChiDaoTaos).HasForeignKey(e => e.NhanVienId);
            });

            modelBuilder.Entity<KyThuatChuyenMon>(entity =>
            {
                entity.ToTable("KyThuatChuyenMon");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id_KyThuat");
                entity.HasOne(e => e.NhanVien).WithMany(nv => nv.KyThuatChuyenMons).HasForeignKey(e => e.NhanVienId);
            });

            modelBuilder.Entity<KyLuat>(entity =>
            {
                entity.ToTable("KyLuat");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id_KyLuat");
                entity.HasOne(e => e.NhanVien).WithMany(nv => nv.KyLuats).HasForeignKey(e => e.NhanVienId);
            });

            modelBuilder.Entity<LichSuChinhSua>(entity =>
            {
                entity.ToTable("LichSuChinhSua");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id_LichSu");
                entity.HasOne(e => e.NhanVien).WithMany(nv => nv.LichSuChinhSuas).HasForeignKey(e => e.NhanVienId).IsRequired(false);
            });

            modelBuilder.Entity<Dm_LoaiDichVu>(entity =>
            {
                entity.ToTable("Dm_LoaiDichVu");
                entity.HasKey(e => e.LoaiDichVuId);
                entity.Property(e => e.LoaiDichVuId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Dm_NhomDichVu>(entity =>
            {
                entity.ToTable("Dm_NhomDichVu");
                entity.HasKey(e => e.NhomDichVuId);
                entity.Property(e => e.NhomDichVuId).ValueGeneratedNever();
                entity.HasOne(e => e.LoaiDichVu).WithMany().HasForeignKey(e => e.LoaiDichVuId);
            });

            modelBuilder.Entity<Dm_DichVu>(entity =>
            {
                entity.ToTable("Dm_DichVu");
                entity.HasKey(e => e.DichVuId);
                entity.Property(e => e.DichVuId).ValueGeneratedNever();
                entity.HasOne(e => e.NhomDichVu).WithMany().HasForeignKey(e => e.NhomDichVuId);
            });

            modelBuilder.Entity<STT>(entity =>
            {
                entity.ToTable("STT");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn(); 
                entity.Property(e => e.Ngay).HasColumnType("date");
            });

            modelBuilder.Entity<BenhNhan>(entity =>
            {
                entity.ToTable("BenhNhan");
                entity.HasKey(e => e.BenhNhan_Id);
                entity.Property(e => e.BenhNhan_Id).UseIdentityColumn();
            });

            modelBuilder.Entity<Dm_PhongBan>(entity =>
            {
                entity.ToTable("Dm_PhongBan");
                entity.HasKey(e => e.PhongBanId);
                entity.Property(e => e.PhongBanId).ValueGeneratedNever();
                entity.HasOne(e => e.Parent).WithMany().HasForeignKey(e => e.CapTren_Id);
            });
        }

        
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }
        
        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries<Domain.Common.BaseEntity>();
            
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }
        }
    }
}