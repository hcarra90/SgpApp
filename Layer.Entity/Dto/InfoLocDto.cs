using System;

namespace Layer.Entity.Dto
{
    public class InfoLocDto
    {
        public int Id { get; set; }
        public int id_farm { get; set; }
        public virtual InfoFarmDto InfoFarm { get; set; }
        public string LocationCuartel { get; set; }
        public int Year { get; set; }
        public string DireccionGd { get; set; }
        public string Jaula { get; set; }
        public int id_crop { get; set; }
        public virtual CropDto Crop { get; set; }
        public DateTime? FechaPlantacion { get; set; }
        public DateTime? FechaTransplante { get; set; }
        public DateTime? FechaSiembra { get; set; }
        public DateTime? FechaEstCosecha { get; set; }
        public decimal? DistEntreHileraM { get; set; }
        public decimal? DistSobreHileraM { get; set; }
        public decimal? SuperficieHa { get; set; }
        public bool? Gmo { get; set; }
        public string CodSemillero { get; set; }
        public string LineaRiego { get; set; }
        public string DistGoterosM { get; set; }
        public string CaudalGoterosLtsSeg { get; set; }
        public string TotLineaRiegoM { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string CodigoPoligono { get; set; }
        public int Owner { get; set; }
        public int id_tipo_agro { get; set; }
        public virtual TipoAgroDto TipoAgro { get; set; }
        public int id_estado { get; set; }
        public virtual EstadoDto Estado { get; set; }
        public DateTime FechaCarga { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
