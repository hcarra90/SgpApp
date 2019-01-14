using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity
{
    [Table("MovimientoCosecha")]
    public class MovimientoCosecha:BaseEntity
    {
        [Required]
        [Column("id_movimiento")]
        public int Id { get; set; }

        [Required]
        [Column("euid")]
        public string euid { get; set; }

        [Required]
        [Column("fecha_cosecha")]
        public DateTime fechaCosecha { get; set; }

        [Required]
        [Column("nombre_bin")]
        public string Bin { get; set; }

        [Required]
        [Column("usuario_cosecha")]
        public string usuario { get; set; }

    }
}
