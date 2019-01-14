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
    /// Representación de la tabla Shipment
    /// </summary>
    [Table("InfoFieldBook")]
    public class Shipment:BaseEntity
    {
        [Key]
        [ScaffoldColumn(false)]
        [Required]
        [Column("id_shipment")]
        public int Id { get; set; }

        [Required]
        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; }

        [Required]
        [Column("correlativo_envio")]
        public int Correlativo { get; set; }

        [Required]
        [Column("shipment_code")]
        public string ShipmentCode { get; set; }

        [Required]
        [Column("fecha_envio")]
        public DateTime FechaEnvio { get; set; }

        [Required]
        [Column("estado_shipment")]
        public string EstadoShipment { get; set; }

        [Required]
        [Column("usuario_shipment")]
        public string Usuario { get; set; }
    }
}
