using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Interface
{
    public interface IShipmentRepository : IGenericRepository<Shipment>
    {
        List<int> GetCajasByEnvase(string codigo);
        CajaEnvioDto GetCorrelativoEnvio(int anio);
        Shipment GetShipmentById(int id);
        List<Shipment> GetShipmentByFecha(DateTime fechaEnvio);
        List<Shipment> GetShipmentCode();
        Shipment GrabaInformacion(Shipment obj, out TransactionalInformation transaction);
        List<EncPackingListDto> GetCajasByshipmentCode(string shipmentCode);
        void BorrarShipment(int id, out TransactionalInformation transaction);

    }
}
