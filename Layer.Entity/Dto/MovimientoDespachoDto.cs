using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Dto
{
    public class MovimientoDespachoDto
    {
        public int Id { get; set; }
        public int IdProgramaExport { get; set; }
        public string Especie { get; set; }
        public string Variedad { get; set; }
        public string Color { get; set; }
        public string Envase { get; set; }
        public string Embalaje { get; set; }
        public decimal PesoEmbalaje { get; set; }
        public string Calibre { get; set; }
        public string CajaPallet { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
        public int? IdTarja { get; set; }
        public int? IdPallet { get; set; }
    }
}
