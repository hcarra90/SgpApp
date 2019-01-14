using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Dto
{
    public class InfoFarmDto
    {
        public int Id { get; set; }
        public int id_empresa { get; set; }
        public virtual EmpresaDto Empresa { get; set; }
        public int Owner { get; set; }
        public string Country { get; set; }
        public string Farm { get; set; }
        public string CodFarm { get; set; }
        public string SubFarm { get; set; }
        public string DireccionGd { get; set; }
        public int id_region { get; set; }
        public virtual RegionDto Region { get; set; }
        public int? id_provincia { get; set; }
        public int? id_ciudad { get; set; }
        public int? id_comuna { get; set; }
        public int id_tipo_contrato { get; set; }
        public virtual TipoContratoDto TipoContrato { get; set; }
        public DateTime? InicioContrato { get; set; }
        public DateTime? TerminoContrato { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string CodigoPoligono { get; set; }
        public int id_estado { get; set; }
        public virtual EstadoDto Estado { get; set; }
        public DateTime FechaCarga { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
