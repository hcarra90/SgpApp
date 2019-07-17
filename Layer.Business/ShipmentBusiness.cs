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
    public class ShipmentBusiness
    {
        #region Declaración
        static readonly IShipmentRepository repository = new ShipmentRepository();
        #endregion

        #region Métodos Públicos

        public static CajaEnvioDto GetCorrelativoEnvio(int anio)
        {
            return repository.GetCorrelativoEnvio(anio);
        }

        public static Shipment GetShipmentById(int id)
        {
            return repository.GetShipmentById(id);
        }

        public static List<Shipment> GetShipmentByFecha(DateTime fechaEnvio)
        {
            return repository.GetShipmentByFecha(fechaEnvio);
        }

        public static List<Shipment> GetShipmentCode()
        {
            return repository.GetShipmentCode();
        }

        public static Shipment GrabaInformacion(Shipment obj, out TransactionalInformation transaction)
        {
            return repository.GrabaInformacion(obj, out transaction);
        }

        public static List<EncPackingListDto> GetCajasByshipmentCode(string shipmentCode)
        {
            return repository.GetCajasByshipmentCode(shipmentCode);
        }

        public static void BorrarShipment(int id, out TransactionalInformation transaction)
        {
            repository.BorrarShipment(id, out transaction);
        }
        public static List<int> GetCajasByEnvase(string codigo)
        {
            return repository.GetCajasByEnvase(codigo);
        }
        #endregion
    }
}
