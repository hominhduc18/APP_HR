using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItoApp.Domain.Entities.ItoCare
{
    [Table("khoa_phong")]
    public class KhoaPhong
    {
        [Key]
        [Column("khoa_id")]
        public int KhoaId { get; set; }

        [Required]
        [Column("chi_nhanh_id")]
        public int ChiNhanhId { get; set; }

        [Required]
        [StringLength(100)]
        [Column("ten_khoa")]
        public string TenKhoa { get; set; } = string.Empty;

        [Column("mo_ta")]
        public string? MoTa { get; set; }

        [Column("icon")]
        public string? Icon { get; set; }

        [Column("la_hoat_dong")]
        public bool LaHoatDong { get; set; } = true;

        // Navigation properties
        [ForeignKey("ChiNhanhId")]
        public virtual ChiNhanh? ChiNhanh { get; set; }

        public virtual ICollection<PhongKham> PhongKhams { get; set; } = new List<PhongKham>();
        public virtual ICollection<BacSi> BacSis { get; set; } = new List<BacSi>();
    }
}
