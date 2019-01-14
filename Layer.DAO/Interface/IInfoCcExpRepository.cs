using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;

namespace Layer.DAO.Interface
{
    /// <summary>
    /// Interfaz con las operaciones del IInfoCcExp
    /// </summary>
    public interface IInfoCcExpRepository : IGenericRepository<CentroCostoExperimento>
    {
        #region Declaración
        List<CentroCostoExperimento> GetCcs();
        CentroCostoExperimento GetCCExpById(int id);
        List<CentroCostoExperimento> GetCCByLoc(int idLoc);
        void Update(CentroCostoExperimento obj);
        void Insert(CentroCostoExperimento obj);
        #endregion
    }
}
