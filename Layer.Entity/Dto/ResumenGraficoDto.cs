using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Dto
{
    public class ResumenGraficoDto
    {
        public List<DataGraficoDto> Movimiento { get; set; }
        public List<DataGraficoDto> Maestro { get; set; }
        public List<ListaValores> Valores { get; set; }
        public int NumeroMovimiento { get; set; }
        public int NumeroRogging { get; set; }
        public int NumeroEuid { get; set; }
        public double PorcentajeProcesado { get; set; }
    }

    public class ListaValores
    {
        public string Nombre { get; set; }
        public int Valor { get; set; }
    }
}
