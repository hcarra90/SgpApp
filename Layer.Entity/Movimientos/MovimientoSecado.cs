using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity
{
    [Table("MovimientoSecado")]
    public class MovimientoSecado:BaseEntity
    {
        [Key]
        [Required]
        [Column("id_movimiento_secado")]
        public int Id { get; set; }

        [Required]
        [Column("euid")]
        public string euid { get; set; }

        [Required]
        [Column("fecha_inicio")]
        public DateTime fechaInicio { get; set; }

        [Required]
        [Column("caja_secador")]
        public string cajaSecador { get; set; }

        [Column("fecha_termino")]
        public DateTime? fechaTermino { get; set; }

        [Required]
        [Column("usuario")]
        public string usuario { get; set; }

    }
}
