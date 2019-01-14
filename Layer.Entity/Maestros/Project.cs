using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Layer.Entity
{
    [Table("Project")]
    public class Project:BaseEntity
    {
        [Key]
        [Required]
        [Column("id_project")]
        public int Id { get; set; }

        [Required]
        public int id_empresa { get; set; }
        [ForeignKey("id_empresa")]
        public virtual Empresa Empresa { get; set; }

        [Required]
        [Column("codigo")]
        public string Codigo { get; set; }
    }
}
