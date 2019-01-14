using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity
{
    [Table("MovimientoCaja")]
    public class MovimientoCaja:BaseEntity
    {
        [Key]
        [ScaffoldColumn(false)]
        [Required]
        [Column("id_movimiento_caja")]
        public int Id { get; set; }

        [Column("ship_to")]
        public string shipTo { get; set; }

        [Column("correlativo_caja")]
        public decimal correlativo { get; set; }

        [Column("caja_envio")]
        public string cajaEnvio { get; set; }

        [Column("fecha_creacion_caja")]
        public DateTime? fechaCreacion { get; set; }

        [Column("fecha_envio")]
        public DateTime? fechaEnvio { get; set; }

        [Column("correlativo_envio")]
        public decimal? correlativoEnvio { get; set; }

        [Column("shipment_code")]
        public string shipmentCode { get; set; }

        [Column("peso_neto_caja")]
        public decimal? pesoNeto { get; set; }

        [Column("peso_bruto_caja")]
        public decimal? pesoBruto { get; set; }

        [Column("pallet")]
        public string pallet { get; set; }

        [Column("peso_pallet")]
        public decimal? pesoPallet { get; set; }

        [Column("bulto")]
        public string bulto { get; set; }

        [Column("peso_bulto")]
        public decimal? pesoBulto { get; set; }

        [Required]
        [Column("usuario")]
        public string usuario { get; set; }

    }
}
