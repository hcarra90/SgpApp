using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Dto
{
    public class MovimientoSecadoDto:InfoFieldBookDto
    {
        public string euid { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime? fechaTermino { get; set; }
        public string cajaSecador { get; set; }
    }
}
