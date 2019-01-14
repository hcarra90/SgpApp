using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;

namespace Layer.DAO.Interface
{
    /// <summary>
    /// Interfaz con las operaciones del InfoLoc
    /// </summary>
    public interface IInfoLocRepository : IGenericRepository<InfoLoc>
    {
        #region Declaración
        List<InfoLocDto> GetLocs();
        InfoLoc GetLocById(int id);
        List<InfoLoc> GetLocByCuartel(string cuartel);
        void Update(InfoLoc obj);
        void Insert(InfoLoc obj);
        #endregion
    }
}
