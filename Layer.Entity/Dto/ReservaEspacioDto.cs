using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Dto
{
    public class ReservaEspacioDto
    {
        public int Id { get; set; }
        public string IdEmpresa { get; set; }
        public string Empresa { get; set; }
        public int IdTipoReserva { get; set; }
        public string TipoReserva { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime? FechaLlegada { get; set; }
        public int IdPais { get; set; }
        public string Pais { get; set; }
        public string ShipTo { get; set; }
        public int? IdPuerto { get; set; }
        public string Puerto { get; set; }
        public string Direccion { get; set; }
        public int IdTipoEnvase { get; set; }
        public string TipoEnvase { get; set; }
        public decimal Largo { get; set; }
        public decimal Ancho { get; set; }
        public decimal Alto { get; set; }
        public decimal KilosNetos { get; set; }
        public decimal KilosBrutos { get; set; }
        public DateTime FechaCarga { get; set; }
        public string UsuarioCarga { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}
