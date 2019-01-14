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
    public static class MovimientoCajaBusiness
    {
        #region Declaración
        static readonly IMovimientoCajaRepository repository = new MovimientoCajaRepository();
       
        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Función que obtiene información de Movimiento de Cajas.
        /// </summary>
        /// <param name="cajaEnvio">Euid</param>
        /// <returns>Devuelve un objeto de tipo MovimientoCaja.</returns>
        public static MovimientoCaja GetCaja(string cajaEnvio)
        {
            return repository.GetCaja(cajaEnvio);
        }

        /// <summary>
        /// Función que obtiene correlativo de Movimiento de Cajas.
        /// </summary>
        /// <param name="shipTo">ShipTo</param>
        /// <returns>Devuelve un objeto de tipo String.</returns>
        public static CajaEnvioDto GetNumeroCaja(string shipTo)
        {
            return repository.GetNumeroCaja(shipTo);
        }

        /// <summary>
        /// Función que obtiene correlativo de Movimiento de Cajas.
        /// </summary>
        /// <param name="shipTo">ShipTo</param>
        /// <returns>Devuelve un objeto de tipo String.</returns>
        public static List<CajaEnvioDto> GetCajasByShipTo(string shipTo)
        {
            return repository.GetCajasByShipTo(shipTo);
        }

        /// <summary>
        /// Función que graba información de Eduid.
        /// </summary>
        /// <param name="euid">Euid</param>
        /// <returns>Devuelve un objeto de tipo MovimientoPacking.</returns>
        public static MovimientoCaja GrabaInformacion(MovimientoCaja movimientoCaja, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            
            try
            {
                if (movimientoCaja.Id == 0)
                {
                    repository.Insert(movimientoCaja);
                }
                else
                {
                    repository.Update(movimientoCaja);
                }
                
                transaction.ReturnStatus = true;
            }
            catch (Exception ex)
            {
                transaction.ReturnStatus = false;
                transaction.ReturnMessage = "Error: " + ex.Message;
            }

            return movimientoCaja;
        }

        /// <summary>
        /// Función que trae Shipment Code
        /// </summary>
        /// <param name=""></param>
        /// <returns>Devuelve un objeto de tipo CajaEnvioDto.</returns>
        public static CajaEnvioDto GetCorrelativoEnvio(int anio)
        {
            return repository.GetCorrelativoEnvio(anio);
        }

        public static List<MovimientoCaja> GetEnviosByFecha(DateTime fechaEnvio)
        {
            return repository.GetEnviosByFecha(fechaEnvio);
        }

        //Reportes

        public static List<ListaShipmentCodeDto> GetshipmentsCode()
        {
            return repository.GetshipmentsCode();
        }
        public static List<EncPackingListDto> GetCajasByshipmentCode(string shipmentCode)
        {
            return repository.GetCajasByshipmentCode(shipmentCode);
        }
        public static List<DetailPackingListDto> GetDetailsByshipmentCode(string shipmentCode)
        {
            return repository.GetDetailsByshipmentCode(shipmentCode);
        }

        public static List<EnvioCajaDto> GetDataByEuid(string cadena, string opcion)
        {
            return repository.GetDataByEuid(cadena,opcion);
        }
        #endregion
    }

}
