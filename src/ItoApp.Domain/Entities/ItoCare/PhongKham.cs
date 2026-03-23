using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItoApp.Domain.Entities.ItoCare
{
    [Table("phong_kham")]
    public class PhongKham
    {
        [Key]
        [Column("phong_id")]
        public int PhongId { get; set; }

        [Required]
        [Column("khoa_id")]
        public int KhoaId { get; set; }

        [Required]
        [StringLength(100)]
        [Column("ten_phong")]
        public string TenPhong { get; set; } = string.Empty;

        [Required]
        [StringLength(5)]
        [Column("tien_to_stt")]
        public string TienToStt { get; set; } = string.Empty;

        [StringLength(20)]
        [Column("tang")]
        public string? Tang { get; set; }

        // Navigation properties
        [ForeignKey("KhoaId")]
        public virtual KhoaPhong? KhoaPhong { get; set; }

        public virtual ICollection<LichLamViec> LichLamViecs { get; set; } = new List<LichLamViec>();
    }
}



