using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;

namespace Layer.DAO.Interface
{
    public interface IEstadoRepository: IGenericRepository<Estado>
    {
        #region Declaración
        List<Estado> GetEstados(int idEmpresa);
        void Update(Estado obj);
        void Insert(Estado obj);
        #endregion
}
}
