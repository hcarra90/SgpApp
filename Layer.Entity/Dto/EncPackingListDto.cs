using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Dto
{
    public class EncPackingListDto
    {
        public int IdMovimiento { get; set; }
        public DateTime? fechaEnvio { get; set; }
        public string shipTo { get; set; }
        public string cajaEnvio { get; set; }
        public string palletEnvio { get; set; }
        public string pesoPallet { get; set; }
        public string bultoEnvio { get; set; }
        public string pesoBulto { get; set; }
        public string pesoNeto { get; set; }
        public string pesoBruto { get; set; }
        public string shipmentCode { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string zipCode { get; set; }
        public string contact { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string client { get; set; }
    }
}
