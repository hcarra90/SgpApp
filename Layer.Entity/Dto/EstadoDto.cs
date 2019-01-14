﻿namespace Layer.Entity.Dto
{
    public class EstadoDto
    {
        public int Id { get; set; }
        public int id_empresa { get; set; }
        public virtual Empresa Empresa { get; set; }
        public string Descripcion { get; set; }
    }
}
