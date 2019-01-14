using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Layer.Entity
{
    [Table("MovimientoFloracion")]
    public class MovimientoFloracion:BaseEntity
    {
        [Required]
        [Column("id_movimiento_floracion")]
        public int Id { get; set; }

        [Required]
        [Column("euid")]
        public string Euid { get; set; }

        [Required]
        [Column("fecha_nota")]
        public DateTime Fecha { get; set; }

        public int id_nota { get; set; }
        [ForeignKey("id_nota")]
        public virtual Nota Nota { get; set; }

        [Required]
        [Column("usuario_floracion")]
        public string Usuario { get; set; }
    }
}
