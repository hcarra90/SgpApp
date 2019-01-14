using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;

namespace Layer.DAO.Interface
{
    /// <summary>
    /// Interfaz con las operaciones del MovimientoPacking
    /// </summary>
    public interface IMovimientoPackingRepository : IGenericRepository<MovimientoPacking>
    {
        #region Declaración
        MovimientoPacking GetEuid(string indEuid, string euid);
        List<MovimientoPacking> GetEuids(string euid);
        #endregion
    }
}
