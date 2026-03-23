using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItoApp.Domain.Entities.ItoCare
{
    [Table("goi_kham")]
    public class GoiKham
    {
        [Key]
        [Column("goi_kham_id")]
        public int GoiKhamId { get; set; }

        [Required]
        [StringLength(200)]
        [Column("ten_goi")]
        public string TenGoi { get; set; } = string.Empty;

        [Column("mo_ta")]
        public string? MoTa { get; set; }

        [Required]
        [Column("gia_goi")]
        public decimal GiaGoi { get; set; }

        [NotMapped]
        public decimal GiaTien => GiaGoi;

        [Column("anh_banner")]
        public string? AnhBanner { get; set; }

        [Column("la_hoat_dong")]
        public bool LaHoatDong { get; set; } = true;

        // Navigation properties
        public virtual ICollection<LichHen> LichHens { get; set; } = new List<LichHen>();
    }
}



