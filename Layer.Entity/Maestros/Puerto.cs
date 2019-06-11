using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity
{
    public class Puerto:BaseEntity
    {
        [Key]
        [Required]
        [Column("id_puerto")]
        public int? Id { get; set; }

        [Required]
        public int id_empresa { get; set; }
        [ForeignKey("id_empresa")]
        public virtual Empresa Empresa { get; set; }

        [Required]
        [Column("codigo_puerto")]
        public string Codigo { get; set; }

        [Required]
        [Column("nombre_puerto")]
        public string Nombre { get; set; }

        [Required]
        public int id_pais { get; set; }
        [ForeignKey("id_pais")]
        public virtual Pais Pais { get; set; }

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
