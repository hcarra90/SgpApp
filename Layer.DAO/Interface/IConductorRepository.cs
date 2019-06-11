using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;

namespace Layer.DAO.Interface
{
    public interface IConductorRepository : IGenericRepository<Conductor>
    {
        #region Declaración
        List<Conductor> GetConductores(int idEmpresa);
        void Update(Conductor obj);
        void Insert(Conductor obj);
        #endregion
    }
}
