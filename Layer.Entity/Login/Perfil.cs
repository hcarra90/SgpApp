using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity
{
    [Table("Perfil")]
    public class Perfil
    {
        [Key]
        [ScaffoldColumn(false)]
        [Required]
        [Column("id_perfil")]
        public int Id { get; set; }

        [Required]
        [Column("nombre_perfil")]
        public string nombrePerfil { get; set; }

        [Required]
        [Column("perfil_activo")]
        public bool perfilActivo { get; set; }

    }
}
