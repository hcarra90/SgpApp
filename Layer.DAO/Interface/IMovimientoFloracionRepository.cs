using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;

namespace Layer.DAO.Interface
{
    public interface IMovimientoFloracionRepository
    {
        #region Declaración
        List<MovimientoFloracionDto> Getfloraciones(DateTime fechaInicio,DateTime fechaTermino);
        void Update(MovimientoFloracion obj);
        void Insert(MovimientoFloracion obj);
        void BorrarEuid(int id, out TransactionalInformation transaction);
        #endregion
    }
}
