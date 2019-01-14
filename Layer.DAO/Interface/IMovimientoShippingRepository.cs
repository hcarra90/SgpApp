using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Interface
{
    /// <summary>
    /// Interfaz con las operaciones del MovimientoShipping
    /// </summary>
    public interface IMovimientoShippingRepository : IGenericRepository<MovimientoShipping>
    {
        #region Declaración
        MovimientoShipping GetEuidById(int id);
        MovimientoShipping GetEuid(string id);
        List<MovimientoShipping> GetBoxesByEuid(string euid, string indEuid, string cajaEnvio);
        List<MovimientoShipping> GetEuidByBox(string box);
        List<ContenidoCajaDto> GetBoxContent(string box);
        MovimientoShipping GetBoxByIndEuid(string indEuid, string cajaEnvio);
        decimal GetBoxWeight(string box);
        List<MovimientoShippingDto> GetEuids(string cadena, string opcion);
        #endregion
    }
}
