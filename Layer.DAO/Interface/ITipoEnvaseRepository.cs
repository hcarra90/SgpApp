using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;

namespace Layer.DAO.Interface
{
    public interface ITipoEnvaseRepository : IGenericRepository<TipoEnvase>
    {
        #region Declaración
        List<TipoEnvase> GetTipoEnvase(int idEmpresa);
        void Update(TipoEnvase obj);
        void Insert(TipoEnvase obj);
        #endregion
    }
}
