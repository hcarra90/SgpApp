using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Dto
{
    public class DataGuiaDespachoDto
    {
        public string Location { get; set; }
        public string Event { get; set; }
        public string Experiment { get; set; }
        public string CentroCosto { get; set; }
        public string CodInternacion { get; set; }
        public int NumeroEuid { get; set; }
        public decimal Peso { get; set; }
        public string Crop { get; set; }
        public string Sag { get; set; }
        public string Ovm { get; set; }
        public string GranosHilera { get; set; }
    }
}
