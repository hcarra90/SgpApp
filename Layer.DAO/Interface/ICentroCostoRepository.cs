using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;
namespace Layer.DAO.Interface
{
    public interface ICentroCostoRepository : IGenericRepository<CentroCosto>
    {
        #region Declaración
        List<CentroCosto> GetCentroCosto(int idEmpresa);
        void Update(CentroCosto obj);
        void Insert(CentroCosto obj);
        #endregion
    }
}
