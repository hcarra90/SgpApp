using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity
{
    [Table("ReservaEspacio")]
    public class ReservaEspacio:BaseEntity
    {
        [Key]
        [Required]
        [ScaffoldColumn(false)]
        [Column("id_reserva_espacio")]
        public int Id { get; set; }

        [Required]
        public int id_empresa { get; set; }
        [ForeignKey("id_empresa")]
        public virtual Empresa Empresa { get; set; }

        [Required]
        [Column("id_tipo_reserva")]
        public int IdTipoReserva { get; set; }

        [Required]
        [Column("fecha_reserva")]
        public DateTime FechaReserva { get; set; }

        [Column("fecha_llegada")]
        public DateTime? FechaLlegada { get; set; }

        [Required]
        public int id_pais { get; set; }
        [ForeignKey("id_pais")]
        public virtual Pais Pais { get; set; }

        [Required]
        [Column("ship_to")]
        public string ShipTo { get; set; }

        public int? id_puerto { get; set; }
        [ForeignKey("id_puerto")]
        public virtual Puerto Puerto { get; set; }

        [Column("direccion")]
        public string Direccion { get; set; }

        [Required]
        public int id_tipo_envase { get; set; }
        [ForeignKey("id_tipo_envase")]
        public virtual TipoEnvase TipoEnvase { get; set; }

        [Required]
        [Column("largo")]
        public decimal Largo { get; set; }

        [Required]
        [Column("ancho")]
        public decimal Ancho { get; set; }

        [Required]
        [Column("alto")]
        public decimal Alto { get; set; }

        [Required]
        [Column("kilos_netos")]
        public decimal KilosNetos { get; set; }

        [Required]
        [Column("kilos_brutos")]
        public decimal KilosBrutos { get; set; }

        [Required]
        [Column("cantidad")]
        public int Cantidad { get; set; }

        [Required]
        [Column("fecha_carga")]
        public DateTime FechaCarga { get; set; }

        [Required]
        [Column("usuario_carga")]
        public string UsuarioCarga { get; set; }

        [Column("fecha_modificacion")]
        public DateTime? FechaModificacion { get; set; }

        [Column("usuario_modificacion")]
        public string UsuarioModificacion { get; set; }
    }
}
