using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItoApp.Domain.Entities.ItoCare
{
    [Table("lich_hen")]
    public class LichHen
    {
        [Key]
        [Column("lich_hen_id")]
        public int LichHenId { get; set; }

        [Required]
        [Column("ho_so_id")]
        public int HoSoId { get; set; }

        [Required]
        [Column("lich_lv_id")]
        public int LichLvId { get; set; }

        [Column("khung_gio_id")]
        public int? KhungGioId { get; set; }

        [Required]
        [Column("ngay_hen")]
        public DateTime NgayHen { get; set; }

        [Required]
        [StringLength(30)]
        [Column("trang_thai")]
        public string TrangThai { get; set; } = "cho_xac_nhan";

        [Column("ly_do_kham")]
        public string? LyDoKham { get; set; }

        [Required]
        [StringLength(20)]
        [Column("loai_kham")]
        public string LoaiKham { get; set; } = "thuong";

        [Column("goi_kham_id")]
        public int? GoiKhamId { get; set; }

        [Column("ngay_tao")]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("HoSoId")]
        public virtual HoSoBenhNhan? HoSoBenhNhan { get; set; }

        [ForeignKey("LichLvId")]
        public virtual LichLamViec? LichLamViec { get; set; }

        [ForeignKey("GoiKhamId")]
        public virtual GoiKham? GoiKham { get; set; }

        public virtual ICollection<LsTrangThai> LichSuTrangThais { get; set; } = new List<LsTrangThai>();
    }
}
