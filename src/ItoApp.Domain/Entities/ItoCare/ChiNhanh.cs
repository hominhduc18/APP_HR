using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using ItoApp.Shared.Exceptions;
using ItoApp.Shared.Enums;
using ItoApp.Shared.ValueObjects;
using ItoApp.Shared.Common;

namespace ItoApp.Domain.Entities.ItoCare
{
    [Table("chi_nhanh")]
    public class ChiNhanh
    {
        [Key]
        [Column("chi_nhanh_id")]
        public int ChiNhanhId { get; set; }

        [Required]
        [StringLength(150)]
        [Column("ten_chi_nhanh")]
        public string TenChiNhanh { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        [Column("dia_chi")]
        public string DiaChi { get; set; } = string.Empty;

        [StringLength(100)]
        [Column("phuong_xa")]
        public string? PhuongXa { get; set; }

        [StringLength(100)]
        [Column("quan_huyen")]
        public string? QuanHuyen { get; set; }

        [StringLength(100)]
        [Column("tinh_thanh")]
        public string? TinhThanh { get; set; }

        [StringLength(15)]
        [Column("so_dien_thoai")]
        public string? SoDienThoai { get; set; }

        [StringLength(150)]
        [Column("email")]
        public string? Email { get; set; }

        [StringLength(100)]
        [Column("gio_hoat_dong")]
        public string? GioHoatDong { get; set; }

        [Column("kinh_do")]
        public decimal? KinhDo { get; set; }

        [Column("vi_do")]
        public decimal? ViDo { get; set; }

        [Column("anh_dai_dien")]
        public string? AnhDaiDien { get; set; }

        [Column("la_hoat_dong")]
        public bool LaHoatDong { get; set; } = true;

        [Column("thu_tu_hien_thi")]
        public int ThuTuHienThi { get; set; } = 0;

        [Column("ngay_tao")]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ICollection<KhoaPhong> KhoaPhongs { get; set; } = new List<KhoaPhong>();
        public virtual ICollection<BsCn> BacSiChiNhanhs { get; set; } = new List<BsCn>();
    }
}



