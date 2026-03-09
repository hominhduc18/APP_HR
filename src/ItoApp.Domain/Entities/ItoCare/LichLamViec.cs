using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItoApp.Domain.Entities.ItoCare
{
    [Table("lich_lam_viec")]
    public class LichLamViec
    {
        [Key]
        [Column("lich_lv_id")]
        public int LichLvId { get; set; }

        [Required]
        [Column("bac_si_id")]
        public int BacSiId { get; set; }

        [Required]
        [Column("phong_id")]
        public int PhongId { get; set; }

        [Required]
        [Column("ngay_lam_viec")]
        public DateTime NgayLamViec { get; set; }

        [Required]
        [StringLength(10)]
        [Column("ca")]
        public string Ca { get; set; } = string.Empty;

        [Required]
        [Column("gio_bat_dau")]
        public TimeSpan GioBatDau { get; set; }

        [Required]
        [Column("gio_ket_thuc")]
        public TimeSpan GioKetThuc { get; set; }

        [Column("so_luong_toi_da")]
        public int SoLuongToiDa { get; set; } = 20;

        [Column("da_dat")]
        public int DaDat { get; set; } = 0;

        // Navigation properties
        [ForeignKey("BacSiId")]
        public virtual BacSi? BacSi { get; set; }

        [ForeignKey("PhongId")]
        public virtual PhongKham? PhongKham { get; set; }

        public virtual ICollection<KhungGio> KhungGios { get; set; } = new List<KhungGio>();
        public virtual ICollection<LichHen> LichHens { get; set; } = new List<LichHen>();
    }
}
