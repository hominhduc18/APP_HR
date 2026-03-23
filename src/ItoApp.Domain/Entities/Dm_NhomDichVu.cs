using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItoApp.Domain.Entities
{
    [Table("Dm_NhomDichVu")]
    public class Dm_NhomDichVu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NhomDichVuId { get; set; }

        public int LoaiDichVuId { get; set; }

        [MaxLength(50)]
        public string MaNhomDichVu { get; set; } = string.Empty;

        [MaxLength(255)]
        public string TenNhomDichVu { get; set; } = string.Empty;

        [MaxLength(255)]
        public string? TenKhongDau { get; set; }

        public int Cap { get; set; }

        public int? CapTren_Id { get; set; }

        public int TraKetQua { get; set; } // 0 or 1

        public int Idx { get; set; }

        public int TamNgung { get; set; } // 0 or 1

        public DateTime? NgayTao { get; set; }
        public int? Login_Id_Tao { get; set; }

        public DateTime? NgayCapNhat { get; set; }
        public int? Login_Id_CapNhat { get; set; }

        public int? CongTy_Id { get; set; }

        public int? Id_Old { get; set; }
        
        public int? STT { get; set; }

        [MaxLength(50)]
        public string? MaSo_SYT { get; set; }

        public int? SoLoaiGia { get; set; }

        [MaxLength(255)]
        public string? TieuDeKetQua { get; set; }

        // Navigation property (Optional, but good for EF)
        [ForeignKey("LoaiDichVuId")]
        public virtual Dm_LoaiDichVu? LoaiDichVu { get; set; }
    }
}



