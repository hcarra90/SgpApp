using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Dto
{
    public class DetailPackingListDto
    {
        public string cajaEnvio { get; set; }
        public string euid { get; set; }
        public string indEuid { get; set; }
        public DateTime fechaPacking { get; set; }
        public string totalWeight { get; set; }
        public string totalKernels { get; set; }
        public string totalEar { get; set; }
        public string country { get; set; }
        public string bc1 { get; set; }
        public string bc2 { get; set; }
        public string bc3 { get; set; }
        public string bc4 { get; set; }
        public string projectLead { get; set; }
        public string cc { get; set; }
        public string shipTo { get; set; }
        public string crop { get; set; }
        public string shipmentCode { get; set; }
        public string location { get; set; }
        public string expName { get; set; }
        public string client { get; set; }
        public string gmoEvent { get; set; }
        public string sag { get; set; }
        public string codInternation { get; set; }
        public string codReception { get; set; }
        public string obs { get; set; }
    }
}
