using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItoApp.Domain.Entities
{
    [Table("Dm_LoaiDichVu")]
    public class Dm_LoaiDichVu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // User allows setting ID manually based on the data provided
        public int LoaiDichVuId { get; set; }

        [MaxLength(50)]
        public string MaLoaiDichVu { get; set; } = string.Empty;

        [MaxLength(255)]
        public string TenLoaiDichVu { get; set; } = string.Empty;

        [MaxLength(255)]
        public string? TenKhongDau { get; set; }

        public int Idx { get; set; }

        public int TamNgung { get; set; } // 0 or 1

        public DateTime? NgayTao { get; set; }
        public int? Login_Id_Tao { get; set; }

        public DateTime? NgayCapNhat { get; set; }
        public int? Login_Id_CapNhat { get; set; }

        public int CongTy_Id { get; set; }

        public int? Id_Old { get; set; }
    }
}



