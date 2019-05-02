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
    /// Representación de la tabla InfoFieldBook
    /// </summary>
    [Table("InfoFieldBook")]
    public class InfoFieldBook : BaseEntity
    {
        [Key]
        [ScaffoldColumn(false)]
        [Required]
        [Column("id_field_book")]
        public int Id { get; set; }

        [Column("euid")]
        public string euid { get; set; }

        [Column("ind_euid")]
        public string indEuid { get; set; }

        [Column("year")]
        public int? year { get; set; }

        [Column("country")]
        public string country { get; set; }

        [Column("location")]
        public string location { get; set; }

        [Column("order")]
        public decimal? order { get; set; }

        [Column("breeders_code1")]
        public string breedersCode1 { get; set; }

        [Column("breeders_code2")]
        public string breedersCode2 { get; set; }

        [Column("breeders_code3")]
        public string breedersCode3 { get; set; }


        [Column("breeders_code4")]
        public string breedersCode4 { get; set; }

        [Column("rng")]
        public string rng { get; set; }

        [Column("plt")]
        public string plt { get; set; }

        [Column("ent")]
        public string ent { get; set; }

        [Column("op_exp_name")]
        public string opExpName { get; set; }

        [Column("project_lead")]
        public string projecLead { get; set; }


        [Column("cc")]
        public string cc { get; set; }


        [Column("shelling")]
        public string shelling { get; set; }


        [Column("instructions")]
        public string instructions { get; set; }


        [Column("targears")]
        public string targears { get; set; }


        [Column("target_kern")]
        public string targetKern { get; set; }


        [Column("target_wg")]
        public decimal? targetWg { get; set; }


        [Column("ship_to")]
        public string shipTo { get; set; }


        [Column("crop")]
        public string crop { get; set; }


        [Column("obs")]
        public string obs { get; set; }

        [Column("project_code")]
        public string projectCode { get; set; }

        [Column("gmo_event")]
        public string gmoEvent { get; set; }

        [Column("sag")]
        public string sag { get; set; }

        [Column("cod_internacion")]
        public string codInternacion { get; set; }

        [Column("cod_reception")]
        public string codReception { get; set; }

        [Column("client")]
        public string client { get; set; }

        [Column("ent_name")]
        public string EntName { get; set; }

        [Column("ent_role")]
        public string EntRole { get; set; }

        [Column("res_importation")]
        public string ResImportation { get; set; }

        [Column("granos_hilera")]
        public int? GranosHilera { get; set; }

        [Column("breeders_instructions_1")]
        public string BreedersInstructions1 { get; set; }
        
        [Column("breeders_instructions_2")]
        public string BreedersInstructions2 { get; set; }
        
        [Column("breeders_instructions_3")]
        public string BreedersInstructions3 { get; set; }

        [Column("breeders_instructions_4")]
        public string BreedersInstructions4 { get; set; }

        [Column("owner")]
        public string Owner { get; set; }

        [Column("cod_permanencia")]
        public string CodPermanencia { get; set; }

        [Column("lot_id")]
        public string LotId { get; set; }

        [Column("fecha_carga")]
        public DateTime fechaCarga { get; set; }

        [Column("fecha_modificacion")]
        public DateTime? fechaModificacion { get; set; }

    }
}
