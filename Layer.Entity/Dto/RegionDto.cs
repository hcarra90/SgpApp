
namespace Layer.Entity.Dto
{
    public class RegionDto
    {
        public int Id { get; set; }
        public int id_empresa { get; set; }
        public virtual EmpresaDto Empresa { get; set; }
        public string Codigo { get; set; }
        public string NombreCorto { get; set; }
        public string NombreLargo { get; set; }
    }
}
