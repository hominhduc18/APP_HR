using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItoApp.Domain.Entities
{
    [Table("TaiKhoanBenhNhan")]
    public class TaiKhoanBenhNhan
    {
        [Key]
        public long Id { get; set; }

        public long BenhNhan_Id { get; set; }

        [ForeignKey("BenhNhan_Id")]
        public virtual BenhNhan? BenhNhan { get; set; }

        [Required]
        [MaxLength(20)]
        public string SoDienThoai { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string MatKhau { get; set; } = string.Empty; // Hashed password

        public bool TrangThai { get; set; } = true; // true: Active, false: Locked

        public DateTime NgayTao { get; set; } = DateTime.UtcNow;
    }
}



