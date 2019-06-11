namespace Layer.Entity.Dto
{
    public class CropDto
    {
        public int Id { get; set; }
        public int id_empresa { get; set; }
        public virtual EmpresaDto Empresa { get; set; }
        public string Descripcion { get; set; }
        public string TipoConversion { get; set; }
        public string EtapaConversion { get; set; }
        public decimal? PesoConversion { get; set; }
    }
}
