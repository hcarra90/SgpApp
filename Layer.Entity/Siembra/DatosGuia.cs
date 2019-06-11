using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Layer.Entity
{
    [Table("DatosGuia")]
    public class DatosGuia: BaseEntity
    {
        [Key]
        [ScaffoldColumn(false)]
        [Required]
        [Column("id_datos_guia")]
        public int Id { get; set; }

        [Required]
        public int id_empresa { get; set; }
        [ForeignKey("id_empresa")]
        public virtual Empresa Empresa { get; set; }

        [Required]
        [Column("fecha_guia")]
        public DateTime? FechaGuia { get; set; }

        [Required]
        [Column("origen")]
        public string Origen { get; set; }

        [Required]
        [Column("destino")]
        public string Destino { get; set; }

        [Required]
        [Column("conductor")]
        public string Conductor { get; set; }

        [Required]
        [Column("rut_conductor")]
        public string Rut { get; set; }

        [Required]
        [Column("patente")]
        public string Patente { get; set; }

        [Required]
        [Column("crop")]
        public string Crop { get; set; }

        [Required]
        [Column("gmo")]
        public bool? Gmo { get; set; }

        [Required]
        [Column("sag")]
        public string Sag { get; set; }

        [Required]
        [Column("Evento")]
        public string Evento { get; set; }

        [Required]
        [Column("location")]
        public string Location { get; set; }

        [Required]
        [Column("op_exp_name")]
        public string Experimento { get; set; }

        [Required]
        [Column("cc")]
        public string Cc { get; set; }

        [Required]
        [Column("cod_internacion")]
        public string CodInternacion { get; set; }

        [Required]
        [Column("numero_euid")]
        public int? NumeroEuid { get; set; }

        [Required]
        [Column("kilos")]
        public decimal? Kilos { get; set; }

        [Required]
        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; }

        [Required]
        [Column("usuario_creacion")]
        public string UsuarioCreacion { get; set; }
    }
}
