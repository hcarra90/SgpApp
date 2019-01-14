using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls;

namespace Layer.Entity
{
    [Table("CentroCostoExperimento")]
    public class CentroCostoExperimento: BaseEntity
    {
        [Key]
        [Required]
        [Column("id_info_cc_exp")]
        public int Id { get; set; }

        [Required]
        public int id_location { get; set; }
        [ForeignKey("id_location")]
        public virtual InfoLoc InfoLoc { get; set; }

        [Required]
        [Column("year")]
        public int Year { get; set; }

        [Required]
        [Column("op_exp_name")]
        public string ExpName { get; set; }

        [Required]
        [Column("project_lead")]
        public string ProjectLead { get; set; }

        //[Required]
        //public int id_centro_costo { get; set; }
        //[ForeignKey("id_centro_costo")]
        //public virtual CentroCosto CentroCosto { get; set; }
        [Required]
        [Column("centro_costo")]
        public string centro_costo { get; set; }

        [Required]
        public int id_crop { get; set; }
        [ForeignKey("id_crop")]
        public virtual Crop Crop { get; set; }

        //[Required]
        //public int id_project_code { get; set; }
        //[ForeignKey("id_project_code")]
        //public virtual Project Project { get; set; }
        [Required]
        public string ProjectCode { get; set; }
        
        [Required]
        [Column("gmo_event")]
        public string Event { get; set; }

        [Required]
        [Column("sag")]
        public string Sag { get; set; }

        [Required]
        [Column("cod_internacion")]
        public string CodInternacion { get; set; }

        [Required]
        [Column("cod_reception")]
        public string CodReception { get; set; }

        //[Required]
        //public int id_cliente { get; set; }
        //[ForeignKey("id_cliente")]
        //public virtual Cliente Cliente { get; set; }
        [Required]
        public string Cliente { get; set; }

        [Required]
        [Column("Res_importacion")]
        public string ResImportacion { get; set; }

        [Required]
        [Column("granos_hilera")]
        public float? GranosHilera { get; set; }

        [Required]
        [Column("breeders_instructions_1")]
        public string BreedersInstructions1 { get; set; }

        [Required]
        [Column("breeders_instructions_2")]
        public string BreedersInstructions2 { get; set; }

        [Required]
        [Column("breeders_instructions_3")]
        public string BreedersInstructions3 { get; set; }

        [Required]
        [Column("breeders_instructions_4")]
        public string BreedersInstructions4 { get; set; }

        [Required]
        [Column("owner")]
        public int Owner { get; set; }

        [Required]
        public int id_tipo_agro { get; set; }
        [ForeignKey("id_tipo_agro")]
        public virtual TipoAgro TipoAgro { get; set; }

        [Required]
        [Column("variedad")]
        public string Variedad { get; set; }

        [Required]
        [Column("dist_entre_hilera_m")]
        public decimal? DistEntreHileraM { get; set; }

        [Required]
        [Column("dist_sobre_hilera_m")]
        public decimal? DistSobreHileraM { get; set; }

        [Required]
        [Column("tot_plantas_ha")]
        public decimal? TotPlantasHa { get; set; }

        [Required]
        [Column("tot_hileras")]
        public int? TotHileras { get; set; }

        [Required]
        [Column("largo_hilera_m")]
        public decimal? LargoHileraM { get; set; }

        [Required]
        [Column("superficie_ha")]
        public decimal? SuperficieHa { get; set; }

        [Required]
        [Column("gmo")]
        public bool? Gmo { get; set; }

        [Required]
        [Column("lat_cc")]
        public string Latitud { get; set; }

        [Required]
        [Column("long_cc")]
        public string Longitud { get; set; }

        [Required]
        [Column("cod_poligono_cc")]
        public string CodigoPoligono { get; set; }

        [Required]
        public int id_estado { get; set; }
        [ForeignKey("id_estado")]
        public virtual Estado Estado { get; set; }

        [Required]
        [Column("numero_euid")]
        public int? NumeroEuid { get; set; }

        [Required]
        [Column("fecha_carga")]
        public DateTime FechaCarga { get; set; }

        [Required]
        [Column("fecha_modificacion")]
        public DateTime? FechaModificacion { get; set; }
    }
}
