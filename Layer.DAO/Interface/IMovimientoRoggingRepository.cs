using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;

namespace Layer.DAO.Interface
{
    public interface IMovimientoRoggingRepository:IGenericRepository<MovimientoRogging>
    {
        List<MovimientoRogging> GetMovimientoRogging(string reason);
        MovimientoRogging GetEuidById(int id);
        MovimientoRogging GrabaInformacion(MovimientoRogging movimiento, out TransactionalInformation transaction);
        void BorrarEuid(int id, out TransactionalInformation transaction);
        List<MovimientoRoggingDto> GetEuids(string cadena, string opcion);
    }
}
