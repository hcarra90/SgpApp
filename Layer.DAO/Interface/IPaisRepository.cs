using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;

namespace Layer.DAO.Interface
{
    public interface IPaisRepository : IGenericRepository<Pais>
    {
        #region Declaración
        List<Pais> GetPais(int idEmpresa);
        void Update(Pais obj);
        void Insert(Pais obj);
        #endregion
    }
}
