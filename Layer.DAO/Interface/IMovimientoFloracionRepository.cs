using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;

namespace Layer.DAO.Interface
{
    public interface IMovimientoFloracionRepository
    {
        #region Declaración
        List<MovimientoNotaDto> Getfloraciones(DateTime fechaInicio,DateTime fechaTermino);
        void Update(MovimientoNota obj);
        void Insert(MovimientoNota obj);
        void BorrarEuid(int id, out TransactionalInformation transaction);
        #endregion
    }
}
