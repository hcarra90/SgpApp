using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Layer.Entity
{
    [Table("TipoContrato")]
    public class TipoContrato:BaseEntity
    {
        [Key]
        [Required]
        [Column("id_tipo_contrato")]
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
