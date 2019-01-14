using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity
{
    public class ResultadoCarga
    {
        public int TotalRows { get; set; }
        public int NumeroActualizados { get; set; }
        public int NumeroInsertados { get; set; }
        public InfoFieldBook UltimoProcesado { get; set; }
        public string HoraInicio { get; set; }
        public string HoraTermino { get; set; }
        public string Error { get; set; }
    }
}
