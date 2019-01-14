using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Layer.Entity
{
    public class CentroCosto:BaseEntity
    {
        [Key]
        [Required]
        [Column("id_centro_costo")]
        public int Id { get; set; }

        [Required]
        public int id_empresa { get; set; }
        [ForeignKey("id_empresa")]
        public virtual Empresa Empresa { get; set; }

        [Required]
        [Column("codigo")]
        public string Codigo { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }
    }
}
