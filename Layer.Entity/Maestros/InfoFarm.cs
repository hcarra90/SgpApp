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
    /// Representación de la tabla InfoFarm
    /// </summary>
    [Table("InfoFarm")]
    public class InfoFarm: BaseEntity
    {
        [Key]
        [Required]
        [Column("id_farm")]
        public int Id { get; set; }

        [Required]
        public int id_empresa { get; set; }
        [ForeignKey("id_empresa")]
        public virtual Empresa Empresa { get; set; }

        [Required]
        [Column("owner")]
        public int Owner { get; set; }

        [Required]
        [Column("country")]
        public string Country { get; set; }

        [Required]
        [Column("farm")]
        public string Farm { get; set; }

        [Required]
        [Column("cod_farm")]
        public string CodFarm { get; set; }

        [Required]
        [Column("sub_farm")]
        public string SubFarm { get; set; }

        [Required]
        [Column("direccion_gd")]
        public string DireccionGd { get; set; }

        [Required]
        public int id_region { get; set; }
        [ForeignKey("id_region")]
        public virtual Region Region { get; set; }

        [Required]
        [Column("id_provincia")]
        public int? id_provincia { get; set; }

        [Required]
        [Column("id_ciudad")]
        public int? id_ciudad { get; set; }

        [Required]
        [Column("id_comuna")]
        public int? id_comuna { get; set; }

        [Required]
        public int? id_tipo_contrato { get; set; }
        [ForeignKey("id_tipo_contrato")]
        public virtual TipoContrato TipoContrato { get; set; }

        [Required]
        [Column("inicio_contrato")]
        public DateTime? InicioContrato { get; set; }

        [Required]
        [Column("termino_contrato")]
        public DateTime? TerminoContrato { get; set; }

        [Column("lat_farm")]
        public string Latitud { get; set; }

        [Column("long_farm")]
        public string Longitud { get; set; }

        [Column("cod_poligono_farm")]
        public string CodigoPoligono { get; set; }

        [Required]
        public int id_estado { get; set; }
        [ForeignKey("id_estado")]
        public virtual Estado Estado { get; set; }

        [Required]
        [Column("fecha_carga")]
        public DateTime FechaCarga { get; set; }

        [Required]
        [Column("fecha_modificacion")]
        public DateTime? FechaModificacion { get; set; }
    }
}
