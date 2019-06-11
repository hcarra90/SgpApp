using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;

namespace Layer.DAO.Interface
{
    public interface IReservaEspacioRepository : IGenericRepository<ReservaEspacio>
    {
        #region Declaración
        List<ReservaEspacioDto> GetReservaEspacio(int idEmpresa, DateTime fecha, DateTime fechaFin);
        void Update(ReservaEspacio obj);
        void Insert(ReservaEspacio obj);
        #endregion
    }
}
