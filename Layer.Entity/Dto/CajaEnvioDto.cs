using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Dto
{
    public class CajaEnvioDto
    {
        public int Id { get; set; }
        public string nuevaCaja { get; set; }
        public decimal correlativo { get; set; }
        public decimal correlativoEnvio { get; set; }
        public string shipmentCode { get; set; }
    }
}
