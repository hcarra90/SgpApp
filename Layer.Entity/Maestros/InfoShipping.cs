using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity
{
    [Table("InfoShipping")]
    public class InfoShipping:BaseEntity
    {
        [Key]
        [ScaffoldColumn(false)]
        [Required]
        [Column("id_info_shipping")]
        public int Id { get; set; }

        [Required]
        [Column("ship_to")]
        public string shipTo { get; set; }

        [Required]
        [Column("country")]
        public string country { get; set; }

        [Required]
        [Column("state")]
        public string state { get; set; }

        [Required]
        [Column("city")]
        public string city { get; set; }

        [Required]
        [Column("address")]
        public string address { get; set; }

        [Required]
        [Column("zipcode")]
        public string zipcode { get; set; }

        [Required]
        [Column("contact")]
        public string contact { get; set; }

        [Required]
        [Column("email")]
        public string email { get; set; }

        [Required]
        [Column("phone")]
        public string phone { get; set; }

        [Required]
        [Column("client")]
        public string client { get; set; }

    }
}
