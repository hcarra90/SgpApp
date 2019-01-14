using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Layer.Entity
{
    //// <summary>
    /// Representación de la tabla Usuario
    /// </summary>
    [Table("Usuario")]
    public class Usuario : BaseEntity
    {
        [Key]
        [Required]
        [Column("id_usuario")]
        [ScaffoldColumn(false)]
        public int id_usuario { get; set; }

        [Required]
        [Column("id_empresa")]
        public int id_empresa { get; set; }

        [Required]
        public int id_perfil { get; set; }
        [ForeignKey("id_perfil")]
        public virtual Perfil Perfil { get; set; }

        [Required]
        [Column("rut")]
        public string rut { get; set; }

        [Required]
        [Column("nombre_usuario")]
        public string nombre_usuario { get; set; }

        [Required]
        [Column("password")]
        public string password { get; set; }

        [Required]
        [Column("nombre")]
        public string nombre { get; set; }

        [Required]
        [Column("apellido")]
        public string apellido { get; set; }

        [Required]
        [Column("email")]
        public string email { get; set; }

        [Required]
        [Column("fono")]
        public string fono { get; set; }

        [Required]
        [Column("primer_acceso")]
        public bool? primer_acceso { get; set; }

        [Required]
        [Column("activo")]
        public bool activo { get; set; }

        [Required]
        [Column("fecha_creacion")]
        public DateTime fecha_creacion { get; set; }

        [Required]
        [Column("usuario_creacion")]
        public string usuario_creacion { get; set; }

        [Required]
        [Column("fecha_modificacion")]
        public DateTime? fecha_modificacion { get; set; }

        [Required]
        [Column("usuario_modificacion")]
        public string usuario_modificacion { get; set; }
    }
}
