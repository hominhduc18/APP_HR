using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItoApp.Domain.Entities
{
    [Table("Dm_PhongBan")]
    public class Dm_PhongBan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PhongBanId { get; set; }

        [MaxLength(50)]
        public string MaPhong { get; set; } = string.Empty;

        [MaxLength(255)]
        public string TenPhong { get; set; } = string.Empty;

        [MaxLength(255)]
        public string? TenKhongDau { get; set; }

        [MaxLength(500)]
        public string? MoTa { get; set; }

        [MaxLength(255)]
        public string? ViTri { get; set; }

        public int? LoaiPhong { get; set; } // -1: Khu vuc?, 1: Phong kham, 2: Can lam sang, 3: Hanh chinh/Khoa phong

        public int Cap { get; set; }

        public int? CapTren_Id { get; set; }

        public int? TruongPhong { get; set; }
        public int? PhoPhong { get; set; }
        public int? PhoPhong2 { get; set; }

        public int Idx { get; set; }

        public int ThucHienCLS { get; set; } // 0 or 1
        public int TamNgung { get; set; } // 0 or 1
        public int QuyTrinh { get; set; } // 0 or 1

        public int ChiNhanh_Id { get; set; }
        public int CongTy_Id { get; set; }

        public int? Id_Old { get; set; }

        public int? GroupCha { get; set; } // ID of parent group if applicable
        
        public int? NhanVien { get; set; } // 0 or 1 (Is Staff Dept?)

        public int? STT { get; set; }
        public int? STTNhom { get; set; }

        [MaxLength(50)]
        public string? KhoaChuyenMon { get; set; } // Example: Orthopedics

        [MaxLength(50)]
        public string? PhanLoai { get; set; } // Example: PhongKham, TienSanh

        // Navigation properties (Optional)
        [ForeignKey("CapTren_Id")]
        public virtual Dm_PhongBan? Parent { get; set; }
    }
}



