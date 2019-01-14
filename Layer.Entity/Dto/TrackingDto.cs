using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Dto
{
    public class TrackingDto
    {
        public List<InfoFieldBook> Info { get; set; }
        public List<EntryList> EntryList { get; set; }
        public List<MovimientoRoggingDto> Rogging { get; set; }
        public List<MovimientoCosechaDto> Cosecha { get; set; }
        public List<MovimientoSecadoDto> Secado { get; set; }
        public List<MovimientoDesgraneDto> Desgrane { get; set; }
        public List<MovimientoPackingDto> Packing { get; set; }
        public List<MovimientoShippingDto> Shipping { get; set; }
        public List<EnvioCajaDto> Caja { get; set; }
    }
}
