using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItoApp.Domain.Entities
{
    [Table("Log_OTP")]
    public class Log_OTP
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string SoDienThoai { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        public string MaOTP { get; set; } = string.Empty;

        public DateTime HieuLucDen { get; set; } // Expire Time

        public bool DaSuDung { get; set; } = false;

        [MaxLength(20)]
        public string LoaiOTP { get; set; } = "REGISTER"; // REGISTER, FORGOT_PASS

        public DateTime NgayTao { get; set; } = DateTime.UtcNow;
    }
}



