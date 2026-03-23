using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItoApp.Domain.Entities.ItoCare
{
    [Table("ket_qua_cls")]
    public class KetQuaCls
    {
        [Key]
        [Column("ket_qua_id")]
        public int KetQuaId { get; set; }

        [Required]
        [Column("ho_so_id")]
        public int HoSoId { get; set; }

        [Column("bac_si_id")]
        public int? BacSiId { get; set; }

        [StringLength(100)]
        [Column("loai_ket_qua")]
        public string? LoaiKetQua { get; set; }

        [Required]
        [StringLength(200)]
        [Column("ten_dich_vu")]
        public string TenDichVu { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Column("nhom_dich_vu")]
        public string NhomDichVu { get; set; } = string.Empty;

        [Required]
        [Column("ngay_thuc_hien")]
        public DateTime NgayThucHien { get; set; }

        [Required]
        [StringLength(4)]
        [Column("nam")]
        public string Nam { get; set; } = string.Empty;

        [Column("ket_luan")]
        public string? KetLuan { get; set; }

        [Column("duong_dan_pdf")]
        public string? DuongDanPdf { get; set; }

        [Column("mo_ta")]
        public string? MoTa { get; set; }

        [Column("hinh_anh_url")]
        public string? HinhAnhUrl { get; set; }

        [Column("duong_dan_pacs")]
        public string? DuongDanPacs { get; set; }

        [Column("da_ky")]
        public bool DaKy { get; set; } = false;

        // Navigation properties
        [ForeignKey("HoSoId")]
        public virtual HoSoBenhNhan? HoSoBenhNhan { get; set; }

        [ForeignKey("BacSiId")]
        public virtual BacSi? BacSi { get; set; }
    }
}



