namespace Layer.Entity.Dto
{
    public class CropDto
    {
        public int Id { get; set; }
        public int id_empresa { get; set; }
        public virtual EmpresaDto Empresa { get; set; }
        public string Descripcion { get; set; }
    }
}
