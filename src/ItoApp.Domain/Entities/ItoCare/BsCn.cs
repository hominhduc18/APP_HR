using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItoApp.Domain.Entities.ItoCare
{
    [Table("bs_cn")]
    public class BsCn
    {
        [Key]
        [Column("bs_cn_id")]
        public int BsCnId { get; set; }

        [Required]
        [Column("bac_si_id")]
        public int BacSiId { get; set; }

        [Required]
        [Column("chi_nhanh_id")]
        public int ChiNhanhId { get; set; }

        // Navigation properties
        [ForeignKey("BacSiId")]
        public virtual BacSi? BacSi { get; set; }

        [ForeignKey("ChiNhanhId")]
        public virtual ChiNhanh? ChiNhanh { get; set; }
    }
}
