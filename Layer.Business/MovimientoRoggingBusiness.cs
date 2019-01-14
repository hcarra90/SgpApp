using Layer.DAO.Interface;
using Layer.DAO.Repositories;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business
{
    public static class MovimientoRoggingBusiness
    {
        #region Declaración
        static readonly IMovimientoRoggingRepository repository = new MovimientoRoggingRepository();

        #endregion

        #region Métodos Públicos
        public static MovimientoRogging GetEuidById(int id)
        {
            return repository.GetEuidById(id);
        }

        public static List<MovimientoRoggingDto> GetEuids(string valor,string opcion)
        {
            return repository.GetEuids(valor,opcion);
        }

        public static List<MovimientoRogging> GetMovimientoRogging(string reason)
        {
            return repository.GetMovimientoRogging(reason);
        }

        public static MovimientoRogging GrabaInformacion(MovimientoRogging movimiento, out TransactionalInformation transaction)
        {
            return repository.GrabaInformacion(movimiento, out transaction);
        }

        public static void BorrarEuid(int id, out TransactionalInformation transaction)
        {
            repository.BorrarEuid(id, out transaction);
        }
        #endregion

    }
}
