using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Layer.Entity
{
    [Table("Nota")]
    public class Nota:BaseEntity
    {
        [Required]
        [Column("id_nota")]
        public int Id {get; set; }

        [Required]
        public int id_empresa { get; set; }
        [ForeignKey("id_empresa")]
        public virtual Empresa Empresa { get; set; }

        [Required]
        [Column("nombre_nota")]
        public string Nombre { get; set; }

        [Required]
        [Column("nota_activa")]
        public bool Activa { get; set; }
    }
}
