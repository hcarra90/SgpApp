using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Dto
{
    public class MovimientoPackingDto:InfoFieldBookDto
    {
        public string euid { get; set; }
        public string indEuid { get; set; }
        public DateTime fechaPacking { get; set; }
        public string totalWeight { get; set; }
        public string totalKernels { get; set; }
        public string totalEars { get; set; }
    }
}
