using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItoApp.Domain.Entities.ItoCare
{
    [Table("ho_so_benh_nhan")]
    public class HoSoBenhNhan
    {
        [Key]
        [Column("ho_so_id")]
        public int HoSoId { get; set; }

        [Required]
        [Column("nguoi_dung_id")]
        public int NguoiDungId { get; set; }

        [StringLength(20)]
        [Column("ma_benh_nhan")]
        public string? MaBenhNhan { get; set; }

        [StringLength(20)]
        [Column("quan_he")]
        public string? QuanHe { get; set; }

        [Required]
        [StringLength(100)]
        [Column("ho_ten")]
        public string HoTen { get; set; } = string.Empty;

        [Required]
        [Column("ngay_sinh")]
        public DateTime NgaySinh { get; set; }

        [Required]
        [StringLength(10)]
        [Column("gioi_tinh")]
        public string GioiTinh { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        [Column("so_dien_thoai")]
        public string SoDienThoai { get; set; } = string.Empty;

        [StringLength(255)]
        [Column("dia_chi")]
        public string? DiaChi { get; set; }

        [StringLength(20)]
        [Column("so_bhyt")]
        public string? SoBHYT { get; set; }

        [Column("ngay_tao")]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("NguoiDungId")]
        public virtual NguoiDung? NguoiDung { get; set; }

        public virtual ICollection<LichHen> LichHens { get; set; } = new List<LichHen>();
        public virtual ICollection<KetQuaCls> KetQuaClss { get; set; } = new List<KetQuaCls>();
    }
}
