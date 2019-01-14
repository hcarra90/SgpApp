using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls;

namespace Layer.Entity.Dto
{
    public class CentroCostoExperimentoDto
    {
        public int Id { get; set; }
        public int id_location { get; set; }
        public string Location { get; set; }
        public string InfoLoc { get; set; }
        public int Year { get; set; }
        public string Country { get; set; }
        public string ExpName { get; set; }
        public string ProjectLead { get; set; }
        public int id_centro_costo { get; set; }
        public string centro_costo { get; set; }
        public int id_crop { get; set; }
        public string Crop { get; set; }
        public string ProjectCode { get; set; }
        public string Event { get; set; }
        public string Sag { get; set; }
        public string CodInternacion { get; set; }
        public string CodReception { get; set; }
        public string Cliente { get; set; }
        public string ResImportacion { get; set; }
        public float? GranosHilera { get; set; }
        public string BreedersInstructions1 { get; set; }
        public string BreedersInstructions2 { get; set; }
        public string BreedersInstructions3 { get; set; }
        public string BreedersInstructions4 { get; set; }
        public int Owner { get; set; }
        public string NombreOwner { get; set; }
        public int id_tipo_agro { get; set; }
        public string TipoAgro { get; set; }
        public string Variedad { get; set; }
        public decimal? DistEntreHileraM { get; set; }
        public decimal? DistSobreHileraM { get; set; }
        public decimal? TotPlantasHa { get; set; }
        public int? TotHileras { get; set; }
        public decimal? LargoHileraM { get; set; }
        public decimal? SuperficieHa { get; set; }
        public bool? Gmo { get; set; }
        public string EsGmo { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string CodigoPoligono { get; set; }
        public int id_estado { get; set; }
        public string Estado { get; set; }
        public int? NumeroEuid { get; set; }
        public DateTime FechaCarga { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
