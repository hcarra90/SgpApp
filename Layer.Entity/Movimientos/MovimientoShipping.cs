using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity
{
    [Table("MovimientoShipping")]
    public class MovimientoShipping:BaseEntity
    {
        [Key]
        [ScaffoldColumn(false)]
        [Required]
        [Column("id_movimiento_shipping")]
        public int Id { get; set; }

        [Required]
        [Column("euid")]
        public string euid { get; set; }

        [Column("ind_euid")]
        public string indEuid { get; set; }

        [Required]
        [Column("fecha_preparacion_shipping")]
        public DateTime fechaPreparacion { get; set; }

        [Required]
        [Column("caja_envio")]
        public string cajaEnvio { get; set; }

        [Required]
        [Column("usuario")]
        public string usuario { get; set; }

    }
}
