using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity
{
    [Table("Pallet")]
    public class Pallet:BaseEntity
    {
        [Key]
        [Required]
        [Column("id_pallet")]
        public int Id { get; set; }

        [Required]
        public int id_empresa { get; set; }
        [ForeignKey("id_empresa")]
        public virtual Empresa Empresa { get; set; }

        [Required]
        [Column("id_tipo_pallet")]
        public int Tipo { get; set; }

        [Required]
        [Column("codigo_pallet")]
        public string Codigo { get; set; }

        [Required]
        [Column("peso_pallet")]
        public decimal Peso { get; set; }

        [Column("material")]
        public string Material { get; set; }

        [Column("medidas")]
        public string Medidas { get; set; }

        [Required]
        [Column("fecha_carga")]
        public DateTime FechaCarga { get; set; }

        [Required]
        [Column("fecha_modificacion")]
        public DateTime? FechaModificacion { get; set; }
    }
}
