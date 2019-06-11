using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;

namespace Layer.DAO.Interface
{
    public interface IPuertoRepository : IGenericRepository<Puerto>
    {
        #region Declaración
        List<Puerto> GetPuerto(int idEmpresa);
        List<PuertoDto> GetPuertoByShipTo(string shipTo);
        void Update(Puerto obj);
        void Insert(Puerto obj);
        #endregion
    }
}
