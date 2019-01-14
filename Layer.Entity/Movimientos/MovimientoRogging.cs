using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity
{
    [Table("MovimientoRogging")]
    public class MovimientoRogging:BaseEntity
    {
        [Key]
        [Required]
        [Column("id_movimiento_rogging")]
        public int Id { get; set; }

        [Required]
        [Column("euid")]
        public string Euid { get; set; }

        [Required]
        [Column("fecha_rogging")]
        public DateTime FechaRogging { get; set; }

        [Required]
        [Column("discard_reason")]
        public string Reason { get; set; }

        [Required]
        [Column("usuario_rogging")]
        public string UsuarioRogging { get; set; }
    }
}
