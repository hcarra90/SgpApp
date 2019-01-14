using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Layer.Entity
{
    [Table("Region")]
    public class Region:BaseEntity
    {
        [Key]
        [Required]
        [Column("id_region")]
        public int Id { get; set; }

        [Required]
        public int id_empresa { get; set; }
        [ForeignKey("id_empresa")]
        public virtual Empresa Empresa { get; set; }

        [Required]
        [Column("codigo")]
        public string Codigo { get; set; }

        [Required]
        [Column("nombre_corto")]
        public string NombreCorto { get; set; }

        [Required]
        [Column("nombre_largo")]
        public string NombreLargo { get; set; }
    }
}
