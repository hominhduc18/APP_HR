using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItoApp.Domain.Entities.ItoCare
{
    [Table("ls_trang_thai")]
    public class LsTrangThai
    {
        [Key]
        [Column("ls_trang_thai_id")]
        public int LsTrangThaiId { get; set; }

        [Required]
        [Column("lich_hen_id")]
        public int LichHenId { get; set; }

        [StringLength(30)]
        [Column("trang_thai_cu")]
        public string? TrangThaiCu { get; set; }

        [Required]
        [StringLength(30)]
        [Column("trang_thai_moi")]
        public string TrangThaiMoi { get; set; } = string.Empty;

        [Column("nguoi_thuc_hien_id")]
        public int? NguoiThucHienId { get; set; }

        [Column("ghi_chu")]
        public string? GhiChu { get; set; }

        [Column("ngay_tao")]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("LichHenId")]
        public virtual LichHen? LichHen { get; set; }

        [ForeignKey("NguoiThucHienId")]
        public virtual NguoiDung? NguoiThucHien { get; set; }
    }
}



