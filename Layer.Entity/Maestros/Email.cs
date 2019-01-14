using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity
{
    public class Email:BaseEntity
    {
        [Required]
        [Column("id_email")]
        public int Id { get; set; }

        [Required]
        [Column("email")]
        public string EmailUsado { get; set; }

    }
}
