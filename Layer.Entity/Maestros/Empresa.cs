using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Layer.Entity
{
    [Table("Empresa")]
    public class Empresa:BaseEntity
    {
        [Key]
        [Required]
        [Column("id_empresa")]
        public int Id { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }
    }
}
