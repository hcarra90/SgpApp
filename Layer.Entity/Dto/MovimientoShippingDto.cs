using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Dto
{
    public class MovimientoShippingDto:InfoFieldBookDto
    {
        public string euid { get; set; }
        public string indEuid { get; set; }
        public DateTime fechaPreparacion { get; set; }
        public string cajaEnvio { get; set; }
    }
}
