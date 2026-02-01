using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItoApp.Domain.Entities
{
    [Table("STT")]
    public class STT
    {
        [Key]
        public long Id { get; set; }

        public DateTime Ngay { get; set; } = DateTime.Now.Date;

        public int SoThuTu { get; set; }

        [MaxLength(20)]
        public string? MaBenhNhan { get; set; }

        [MaxLength(255)]
        public string HoTen { get; set; } = string.Empty;

        public int? NamSinh { get; set; }

        [MaxLength(10)]
        public string? GioiTinh { get; set; }

        [MaxLength(500)]
        public string? DiaChi { get; set; }

        [MaxLength(50)]
        public string? DienThoai { get; set; }

        public int DoiTuong { get; set; } // 0: Thu Phi, 1: BHYT

        [MaxLength(50)]
        public string? SoTheBHYT { get; set; }

        public DateTime? HanThe_Tu { get; set; }
        public DateTime? HanThe_Den { get; set; }

        [MaxLength(20)]
        public string? MaDKBD { get; set; }

        public int? PhongId { get; set; }
        public int? BacSiId { get; set; }

        public int TrangThai { get; set; } // 0: Chờ khám, 1: Đang khám, 2: Đã khám

        [MaxLength(500)]
        public string? LyDoKham { get; set; }

        [MaxLength(500)]
        public string? ChanDoanNoiGioiThieu { get; set; }

        public DateTime? NgayTao { get; set; }
        public int? NguoiTao_Id { get; set; }
        
        public int? CongTy_Id { get; set; }
        public int? ChiNhanh_Id { get; set; }
    }
}
