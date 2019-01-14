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
    /// Representación de la tabla InfoLoc
    /// </summary>
    [Table("InfoLoc")]
    public class InfoLoc:BaseEntity
    {
        [Key]
        [Required]
        [Column("id_loc")]
        public int Id { get; set; }

        [Required]
        public int id_farm { get; set; }
        [ForeignKey("id_farm")]
        public virtual InfoFarm InfoFarm { get; set; }

        [Required]
        [Column("location_cuartel")]
        public string LocationCuartel { get; set; }

        [Required]
        [Column("year")]
        public int Year { get; set; }

        [Required]
        [Column("direccion_gd")]
        public string DireccionGd { get; set; }

        [Column("jaula")]
        public string Jaula { get; set; }

        [Required]
        public int id_crop { get; set; }
        [ForeignKey("id_crop")]
        public virtual Crop Crop { get; set; }

        [Column("fecha_plantacion")]
        public DateTime? FechaPlantacion { get; set; }

        [Column("fecha_transplante")]
        public DateTime? FechaTransplante { get; set; }

        [Column("fecha_siembra")]
        public DateTime? FechaSiembra { get; set; }

        [Required]
        [Column("fecha_est_cosecha")]
        public DateTime? FechaEstCosecha { get; set; }

        [Required]
        [Column("dist_entre_hilera_m")]
        public decimal? DistEntreHileraM { get; set; }

        [Required]
        [Column("dist_sobre_hilera_m")]
        public decimal? DistSobreHileraM { get; set; }

        [Required]
        [Column("superficie_ha")]
        public decimal? SuperficieHa { get; set; }

        [Column("gmo")]
        public bool? Gmo { get; set; }

        [Column("cod_semillero")]
        public string CodSemillero { get; set; }

        [Required]
        [Column("linea_riego")]
        public string LineaRiego { get; set; }

        [Required]
        [Column("dist_goteros_m")]
        public string DistGoterosM { get; set; }

        [Required]
        [Column("caudal_goteros_lts_seg")]
        public string CaudalGoterosLtsSeg { get; set; }

        [Required]
        [Column("tot_linea_riego_m")]
        public string TotLineaRiegoM { get; set; }

        [Required]
        [Column("lat_loc")]
        public string Latitud { get; set; }

        [Required]
        [Column("long_loc")]
        public string Longitud { get; set; }

        [Required]
        [Column("cod_poligono_loc")]
        public string CodigoPoligono { get; set; }

        [Required]
        [Column("owner")]
        public int Owner { get; set; }

        [Required]
        public int id_tipo_agro { get; set; }
        [ForeignKey("id_tipo_agro")]
        public virtual TipoAgro TipoAgro { get; set; }

        [Required]
        public int id_estado { get; set; }
        [ForeignKey("id_estado")]
        public virtual Estado Estado { get; set; }

        [Required]
        [Column("fecha_carga")]
        public DateTime FechaCarga { get; set; }

        [Column("fecha_modificacion")]
        public DateTime? FechaModificacion { get; set; }
    }
}
