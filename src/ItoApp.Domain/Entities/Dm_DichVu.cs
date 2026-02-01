using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItoApp.Domain.Entities
{
    [Table("Dm_DichVu")]
    public class Dm_DichVu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DichVuId { get; set; }

        public int NhomDichVuId { get; set; }

        [MaxLength(50)]
        public string MaDichVu { get; set; } = string.Empty;

        [MaxLength(500)]
        public string TenDichVu { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? TenKhongDau { get; set; }

        public int Cap { get; set; }

        public int? CapTren_Id { get; set; }

        [MaxLength(50)]
        public string? DonViTinh { get; set; }

        public int Idx { get; set; }

        public int? BHYT { get; set; } // 0 or 1

        public int TamNgung { get; set; } // 0 or 1

        [Column(TypeName = "decimal(18, 2)")]
        public decimal DonGia { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? DonGiaBHYT { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? DonGiaNuocNgoai { get; set; }

        public int? CongTy_Id { get; set; }

        public int? TyLeVAT { get; set; }

        public int? SoLanThucHien { get; set; }

        public int? Id_Old { get; set; }

        public string? KhoangCachGroup { get; set; }

        public int? CoGia { get; set; }

        public int? TraKetQuaMien { get; set; }

        public string? TenNhom { get; set; }
        
        public double? HeSo { get; set; }

        public int? DoanhThu { get; set; }
        public int? DoanhThuBHYT { get; set; }
        public int? ThucHien { get; set; } // 0/1 for external/internal execution?

        [MaxLength(50)]
        public string? MaGoiTu { get; set; }

        public string? NguoiTao { get; set; }
        public int? Login_Id_Tao { get; set; }
        public DateTime? NgayTao { get; set; }

        public int? Login_Id_CapNhat { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        
        public int? SoLoaiGia { get; set; }
        
        public int? MapBHYT { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? DonGia2 { get; set; }

        // Navigation
        [ForeignKey("NhomDichVuId")]
        public virtual Dm_NhomDichVu? NhomDichVu { get; set; }
    }
}
