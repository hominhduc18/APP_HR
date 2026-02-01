using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItoApp.Domain.Entities
{
    [Table("BenhNhan")]
    public class BenhNhan
    {
        [Key]
        public long BenhNhan_Id { get; set; }

        [MaxLength(20)]
        public string? MaYTe { get; set; }

        [MaxLength(255)]
        public string TenBenhNhan { get; set; } = string.Empty;

        [MaxLength(255)]
        public string? TenKhongDau { get; set; }

        public DateTime? NgaySinh { get; set; }

        [MaxLength(10)]
        public string? GioiTinh { get; set; } // T: Trai, G: Gai ?

        public int? TheoDoiTienSu { get; set; }

        [MaxLength(50)]
        public string? SoDienThoai { get; set; }

        [MaxLength(20)]
        public string? CMND { get; set; }

        public DateTime? NgayCap { get; set; }

        public int? QuocTich_Id { get; set; }
        public int? TinhThanh_Id { get; set; }
        public int? QuanHuyen_Id { get; set; }
        public int? XaPhuong_Id { get; set; }

        [MaxLength(200)]
        public string? SoNha { get; set; }

        [MaxLength(500)]
        public string? DiaChi { get; set; }

        [MaxLength(20)]
        public string? NhomMau { get; set; }

        public int? YeuToRh_Id { get; set; } // MauRh_Id in image?

        [MaxLength(1000)]
        public string? TienSu { get; set; }

        public int? NgheNghiep_Id { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(200)]
        public string? NguoiLienHe { get; set; }

        [MaxLength(50)]
        public string? SoDienThoaiNguoiLienHe { get; set; }

        public int? CongTy_Id { get; set; }
        public int? ChiNhanh_Id { get; set; }
        public int? TiepNhan_Id { get; set; }
        public int? BenhAn_Id_CLS { get; set; }

        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public int? Id_Old { get; set; }

        public int? NguoiTao_Id { get; set; }
        public int? Login_Id_Tao { get; set; }
        public DateTime? NgayTao { get; set; }

        public int? DanToc_Id { get; set; }
        
        [MaxLength(255)]
        public string? NoiLamViec { get; set; }
    }
}
