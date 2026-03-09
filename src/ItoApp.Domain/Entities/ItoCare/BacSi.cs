using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItoApp.Domain.Entities.ItoCare
{
    [Table("bac_si")]
    public class BacSi
    {
        [Key]
        [Column("bac_si_id")]
        public int BacSiId { get; set; }

        [Required]
        [Column("khoa_id")]
        public int KhoaId { get; set; }

        [Required]
        [StringLength(100)]
        [Column("ho_ten")]
        public string HoTen { get; set; } = string.Empty;

        [StringLength(50)]
        [Column("chuc_danh")]
        public string? ChucDanh { get; set; }

        [Column("anh_dai_dien")]
        public string? AnhDaiDien { get; set; }

        [Column("gioi_thieu")]
        public string? GioiThieu { get; set; }

        // Navigation properties
        [ForeignKey("KhoaId")]
        public virtual KhoaPhong? KhoaPhong { get; set; }

        public virtual ICollection<BsCn> BacSiChiNhanhs { get; set; } = new List<BsCn>();
        public virtual ICollection<LichLamViec> LichLamViecs { get; set; } = new List<LichLamViec>();
    }
}
