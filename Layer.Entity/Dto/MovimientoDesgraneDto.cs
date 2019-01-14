using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Dto
{
    public class MovimientoDesgraneDto: InfoFieldBookDto
    {
        public string euid { get; set; }
        public DateTime fecha { get; set; }
        public string sheller { get; set; }
    }
}
