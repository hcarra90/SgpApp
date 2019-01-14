using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Layer.Entity
{
    [Table("Crop")]
    public class Crop:BaseEntity
    {
        [Key]
        [Required]
        [Column("id_crop")]
        public int Id { get; set; }

        [Required]
        public int id_empresa { get; set; }
        [ForeignKey("id_empresa")]
        public virtual Empresa Empresa { get; set; }

        [Required]
        [Column("descripcion")]
        public string Descripcion { get; set; }
    }
}
