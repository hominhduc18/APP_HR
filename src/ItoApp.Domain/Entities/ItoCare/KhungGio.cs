using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItoApp.Domain.Entities.ItoCare
{
    [Table("khung_gio")]
    public class KhungGio
    {
        [Key]
        [Column("khung_gio_id")]
        public int KhungGioId { get; set; }

        [Required]
        [Column("lich_lv_id")]
        public int LichLvId { get; set; }

        [Required]
        [Column("thoi_gian")]
        public TimeSpan ThoiGian { get; set; }

        [Column("da_dat")]
        public bool DaDat { get; set; } = false;

        // Navigation properties
        [ForeignKey("LichLvId")]
        public virtual LichLamViec? LichLamViec { get; set; }
    }
}
