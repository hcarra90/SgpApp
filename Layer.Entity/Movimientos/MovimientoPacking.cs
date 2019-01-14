using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity
{
    //// <summary>
    /// Representación de la tabla MovimientoPacking
    /// </summary>
    [Table("MovimientoPacking")]
    public class MovimientoPacking:BaseEntity
    {
        [Key]
        [ScaffoldColumn(false)]
        [Required]
        [Column("id_movimiento_packing")]
        public int Id { get; set; }

        [Required]
        [Column("euid")]
        public string euid { get; set; }

        [Column("ind_euid")]
        public string indEuid { get; set; }

        [Required]
        [Column("fecha_packing")]
        public DateTime fechaPacking { get; set; }

        [Required]
        [Column("total_weight")]
        public decimal? totalWeight { get; set; }

        [Required]
        [Column("total_kernels")]
        public int? totalKernels { get; set; }

        [Required]
        [Column("total_ears")]
        public int? totalEars { get; set; }

        [Required]
        [Column("usuario")]
        public string usuario { get; set; }

    }
}
