using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Dto
{
    public class EnvioCajaDto
    {
        public string shipTo { get; set; }
        public string cajaEnvio { get; set; }
        public DateTime? creacion { get; set; }
        public DateTime? envio { get; set; }
        public string shipmentCode { get; set; }
        public string pesoNeto { get; set; }
        public string pesoBruto { get; set; }
    }
}
