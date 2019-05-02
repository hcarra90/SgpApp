using Layer.DAO;
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
    public static class MovimientoShippingBusiness
    {
        #region Declaración
        static readonly IMovimientoShippingRepository repository = new MovimientoShippingRepository();
        static readonly IMovimientoCajaRepository repositoryCaja = new MovimientoCajaRepository();
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<MovimientoShipping> repositoryS;
        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Función que obtiene información de Eduid.
        /// </summary>
        /// <param name="box">Euid</param>
        /// <returns>Devuelve un objeto de tipo MovimientoShipping>.</returns>
        public static List<MovimientoShipping> GetEuidByBox(string box)
        {
            return repository.GetEuidByBox(box);
        }

        public static MovimientoShipping GetEuidById(int id)
        {
            repositoryS = unitOfWork.Repository<MovimientoShipping>();
            var item=repositoryS.Table.Where(mc => mc.Id == id).FirstOrDefault();
            return item;//repository.GetEuidById(id);
        }

        public static MovimientoShipping GetEuid(string euid)
        {
            return repository.GetEuid(euid);
        }

        /// <summary>
        /// Función que graba información de Eduid.
        /// </summary>
        /// <param name="euid">Euid</param>
        /// <returns>Devuelve un objeto de tipo MovimientoPacking.</returns>
        public static MovimientoShipping GrabaInformacion(MovimientoShipping movimientoShipping, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            try
            {
                if (movimientoShipping.Id == 0)
                {
                    repository.Add(movimientoShipping);
                }
            }
            catch (Exception ex)
            {
                transaction.ReturnStatus = false;
                transaction.ReturnMessage = "Error: " + ex.Message;
            }

            return movimientoShipping;
        }

        /// <summary>
        /// Función que elimina información de Eduid.
        /// </summary>
        /// <param name="euid">Euid</param>
        /// <returns></returns>
        public static void BorrarEuid(int id, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            repositoryS = unitOfWork.Repository<MovimientoShipping>();

            try
            {
                var entity = GetEuidById(id);
                repositoryS.Delete(entity);
            }
            catch (Exception ex)
            {
                transaction.ReturnStatus = false;
                transaction.ReturnMessage = "Error: " + ex.Message;
            }
        }

        /// <summary>
        /// Función que trae Euid de Cajas 
        /// </summary>
        /// <param name="box"></param>
        /// <returns>Devuelve una lista de objetos de tipo ContenidoCajaDto.</returns>
        public static List<ContenidoCajaDto> GetBoxContent(string box)
        {
            return repository.GetBoxContent(box);
        }

        /// <summary>
        /// Función que trae Peso Neto de Cajas 
        /// </summary>
        /// <param name="box"></param>
        /// <returns>decimal</returns>
        public static decimal GetBoxWeight(string box)
        {
            return repository.GetBoxWeight(box);
        }

        /// <summary>
        /// Función que obtiene información de Movimiento de Cajas.
        /// </summary>
        /// <param name="cajaEnvio">Euid</param>
        /// <returns>Devuelve un objeto de tipo MovimientoCaja.</returns>
        public static MovimientoCaja GetCaja(string cajaEnvio)
        {
            return repositoryCaja.GetCaja(cajaEnvio);
        }

        /// <summary>
        /// Función que obtiene información de las cajas de un euid o individual euid.
        /// </summary>
        /// <param name="euid">Euid</param>
        /// <param name="indEuid">Euid</param>
        /// <returns>Devuelve una lista</returns>
        public static List<MovimientoShipping> GetBoxesByEuid(string euid, string indEuid, string cajaEnvio)
        {
            return repository.GetBoxesByEuid(euid, indEuid,cajaEnvio);
        }

        public static MovimientoShipping GetBoxByIndEuid(string indEuid, string cajaEnvio)
        {
            return repository.GetBoxByIndEuid(indEuid, cajaEnvio);
        }

        public static List<MovimientoShippingDto> GetEuids(string cadena, string opcion)
        {
            return repository.GetEuids(cadena,opcion);
        }
        
        #endregion
    }
}
