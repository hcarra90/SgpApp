using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity
{
    [Table("Parametro")]
    public class Parametro:BaseEntity
    {
        [Key]
        [Required]
        [Column("id_parametro")]
        public int Id { get; set; }

        [Required]
        public int id_empresa { get; set; }
        [ForeignKey("id_empresa")]
        public virtual Empresa Empresa { get; set; }

        [Required]
        [Column("valor_parametro")]
        public string Valor { get; set; }

        [Required]
        [Column("tipo")]
        public string Tipo { get; set; }

        [Required]
        [Column("descripcion")]
        public string Descripcion { get; set; }

    }
}
