using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity
{
    [Table("ProgramaExport")]
    public class ProgramaExport:BaseEntity
    {
        [Key]
        [ScaffoldColumn(false)]
        [Required]
        [Column("id_programa_export")]
        public int Id { get; set; }

        [Required]
        public int id_empresa { get; set; }
        [ForeignKey("id_empresa")]
        public virtual Empresa Empresa { get; set; }

        [Required]
        [Column("id")]
        public int IdPallet { get; set; }

        [Required]
        [Column("especie")]
        public string Especie { get; set; }

        [Required]
        [Column("variedad")]
        public string Variedad { get; set; }

        [Required]
        [Column("color")]
        public string Color { get; set; }

        [Required]
        [Column("envase")]
        public string Envase { get; set; }

        [Required]
        [Column("embalaje")]
        public string Embalaje { get; set; }

        [Required]
        [Column("peso_embalaje")]
        public decimal PesoEmbalaje { get; set; }

        [Required]
        [Column("calibre")]
        public string Calibre { get; set; }

        [Required]
        [Column("caja_pallet")]
        public string CajaPallet { get; set; }

        [Required]
        [Column("fecha_carga")]
        public DateTime FechaCarga { get; set; }

        [NotMapped]
        public string Opcion { get; set; }

        [Required]
        [Column("usuario_carga")]
        public string UsuarioCarga { get; set; }

        [Column("fecha_modificacion")]
        public DateTime? FechaModificacion { get; set; }

        [Column("usuario_modificacion")]
        public string UsuarioModificacion { get; set; }
    }
}
