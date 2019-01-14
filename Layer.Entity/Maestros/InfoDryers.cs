using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity
{
    //// <summary>
    /// Representación de la tabla InfoFieldBook
    /// </summary>
    [Table("InfoDryers")]
    public class InfoDryers
    {
        [Required]
        [Column("id_info_dryes")]
        public int Id { get; set; }

        [Required]
        [Column("dryer_bins")]
        public string dryerBins { get; set; }

        [Required]
        [Column("plastic_bins")]
        public string plasticBins { get; set; }

        [Required]
        [Column("shellers")]
        public string shellers { get; set; }

    }
}
