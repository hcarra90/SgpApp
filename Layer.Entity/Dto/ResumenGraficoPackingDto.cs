using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Dto
{
    public class ResumenGraficoPackingDto
    {
        public string Experimento { get; set; }
        public int CountEuid { get; set; }
        public int EuidRog { get; set; }
        public int CountIndEuid { get; set; }
        public int PackIndEuid { get; set; }
        public double PorcentajeProcesado { get; set; }
        public int TotalEuid { get; set; }
        public int TotalIndEuid { get; set; }
    }
}
