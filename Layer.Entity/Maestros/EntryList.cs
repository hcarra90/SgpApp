using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Layer.Entity
{
    [Table("EntryList")]
    public class EntryList:BaseEntity
    {
        [Key]
        [Required]
        [Column("id_entry_list")]
        public int Id { get; set; }

        [Required]
        [Column("euid")]
        public string Euid { get; set; }

        [Column("year")]
        public int? Year { get; set; }

        [Column("country")]
        public string Country { get; set; }

        [Column("location")]
        public string Location { get; set; }

        [Column("rng")]
        public string Rng { get; set; }

        [Column("plt")]
        public string Plt { get; set; }

        [Column("ent")]
        public string Ent { get; set; }

        [Column("op_exp_name")]
        public string ExpName { get; set; }

        [Column("project_lead")]
        public string ProjectLead { get; set; }

        [Column("cc")]
        public string Cc { get; set; }

        [Column("crop")]
        public string Crop { get; set; }

        [Column("obs")]
        public string Obs { get; set; }

        [Column("project_code")]
        public string ProjectCode { get; set; }

        [Column("gmo_event")]
        public string GmoEvent { get; set; }

        [Column("sag")]
        public string Sag { get; set; }

        [Column("cod_internacion")]
        public string CodInternacion { get; set; }

        [Column("cod_reception")]
        public string CodReception { get; set; }

        [Column("client")]
        public string Client { get; set; }

        [Column("ent_name")]
        public string EntName { get; set; }

        [Column("ent_role")]
        public string EntRole { get; set; }

        [Column("res_importacion")]
        public string ResImportacion { get; set; }

        [Column("granos_hilera")]
        public string GranosHilera { get; set; }

        [Column("breeders_instruction_1")]
        public string Bi1 { get; set; }

        [Column("breeders_instruction_2")]
        public string Bi2 { get; set; }

        [Column("breeders_instruction_3")]
        public string Bi3 { get; set; }

        [Column("breeders_instruction_4")]
        public string Bi4 { get; set; }

        [Column("owner")]
        public string Owner { get; set; }

        [Column("cod_permanencia")]
        public string CodPermanencia { get; set; }

        [Column("lot_id")]
        public string LotId { get; set; }

        [Column("fecha_carga")]
        public DateTime? FechaCarga { get; set; }

        [Column("fecha_modificacion")]
        public DateTime? FechaModificacion{ get; set; }

        [Column("usuario_modificacion")]
        public string UsuarioModificacion { get; set; }

    }
}
