using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;

namespace Layer.DAO.Interface
{
    public interface IMovimientoFloracionRepository
    {
        #region Declaración
        List<MovimientoFloracion> Getfloraciones();
        void Update(MovimientoFloracion obj);
        void Insert(MovimientoFloracion obj);
        #endregion
    }
}
