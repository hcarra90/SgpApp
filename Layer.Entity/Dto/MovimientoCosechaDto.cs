using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Dto
{
    public class MovimientoCosechaDto: InfoFieldBookDto
    {
        public int IdCosecha { get; set; }
        public string Euid { get; set; }
        public DateTime FechaCosecha { get; set; }
        public string Bin { get; set; }
        public string Usuario { get; set; }
    }
}
