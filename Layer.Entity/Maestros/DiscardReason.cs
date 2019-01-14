using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls;

namespace Layer.Entity
{
    [Table("DiscardReason")]
    public class DiscardReason:BaseEntity
    {
        [Key]
        [Required]
        [Column("id_discard_reason")]
        public int Id { get; set; }

        [Required]
        [Column("discard_reason")]
        public string Reason { get; set; }
    }
}
