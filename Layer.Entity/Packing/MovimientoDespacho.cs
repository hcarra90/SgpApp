using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity
{
    [Table("MovimientoDespacho")]
    public class MovimientoDespacho:BaseEntity
    {
        [Required]
        [Column("id_movimiento_despacho")]
        public int Id { get; set; }

        [Required]
        [Column("id_programa_export")]
        public int IdProgramaExport { get; set; }

        [Required]
        [Column("fecha")]
        public DateTime Fecha { get; set; }

        [Required]
        [Column("usuario")]
        public string Usuario { get; set; }

        [Column("id_tarja")]
        public int? IdTarja { get; set; }

        [Column("id_pallet")]
        public int? IdPallet { get; set; }

    }
}
