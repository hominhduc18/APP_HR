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
    [Table("nguoi_dung")]
    public class NguoiDung
    {
        [Key]
        [Column("nguoi_dung_id")]
        public int NguoiDungId { get; set; }

        [Required]
        [StringLength(15)]
        [Column("so_dien_thoai")]
        public string SoDienThoai { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        [Column("mat_khau")]
        public string MatKhau { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [Column("ho_ten")]
        public string HoTen { get; set; } = string.Empty;

        [StringLength(150)]
        [Column("email")]
        public string? Email { get; set; }

        [Column("anh_dai_dien")]
        public string? AnhDaiDien { get; set; }

        [Required]
        [StringLength(20)]
        [Column("vai_tro")]
        public string VaiTro { get; set; } = "benh_nhan";

        [Column("token_thiet_bi")]
        public string? TokenThietBi { get; set; }

        [Column("da_xac_minh")]
        public bool DaXacMinh { get; set; } = false;

        [Column("la_hoat_dong")]
        public bool LaHoatDong { get; set; } = true;

        [Column("ngay_tao")]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        [Column("ngay_cap_nhat")]
        public DateTime? NgayCapNhat { get; set; }

        // Navigation properties
        public virtual ICollection<HoSoBenhNhan> HoSoBenhNhans { get; set; } = new List<HoSoBenhNhan>();
        public virtual ICollection<LsTrangThai> LichSuTrangThais { get; set; } = new List<LsTrangThai>();
    }
}



