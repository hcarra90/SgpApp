using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Layer.Entity
{
    [Table("Cliente")]
    public class Cliente:BaseEntity
    {
        [Key]
        [Required]
        [Column("id_cliente")]
        public int Id { get; set; }

        [Required]
        public int id_empresa { get; set; }
        [ForeignKey("id_empresa")]
        public virtual Empresa Empresa { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }
    }
}
