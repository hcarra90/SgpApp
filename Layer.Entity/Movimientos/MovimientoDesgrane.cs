using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity
{
    [Table("MovimientoDesgrane")]
    public class MovimientoDesgrane:BaseEntity
    {
        [Required]
        [Column("id_movimiento_desgrane")]
        public int Id { get; set; }

        [Required]
        [Column("euid")]
        public string euid { get; set; }

        [Required]
        [Column("fecha_desgrane")]
        public DateTime fechaDesgrane { get; set; }

        [Required]
        [Column("sheller")]
        public string sheller { get; set; }

        [Required]
        [Column("usuario")]
        public string usuario { get; set; }

    }
}
