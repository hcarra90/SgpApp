using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Dto
{
    public class EficienciaPorDiaDto
    {
        public List<ResumenEficienciaDto> Resumen { get; set; }
        public List<DetalleEficienciaDto> Detalle { get; set; }
    }

    public class ResumenEficienciaDto
    {
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
        public string NumeroEuid { get; set; }
        public string NumeroIndEuid { get; set; }
        public TimeSpan Hora { get; set; }
        public string EuidHora { get; set; }
    }

    public class DetalleEficienciaDto
    {
        public DateTime FechaPacking { get; set; }
        public DateTime Fecha { get; set; }
        public string Euid { get; set; }
        public string IndEuid { get; set; }
        public string Usuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Crop { get; set; }
        public string Client { get; set; }
        public string ProjectLead { get; set; }
        public string Location { get; set; }
        public string ExpName { get; set; }
        public string GmoEvent { get; set; }
        public string Sag { get; set; }
        public TimeSpan Time { get; set; }
        public string EuidHora { get; set; }
        public string Sheller { get; set; }
    }
}
