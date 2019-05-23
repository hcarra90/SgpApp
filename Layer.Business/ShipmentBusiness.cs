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
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<Shipment> repository;
        private static Repository<MovimientoCaja> repositoryMC;
        #endregion

        #region Métodos Públicos

        public static CajaEnvioDto GetCorrelativoEnvio(int anio)
        {
            decimal correlativoEnvio = 1;
            string shipmentCode = "";
            CajaEnvioDto newCaja = new CajaEnvioDto();
            repository = unitOfWork.Repository<Shipment>();

            try
            {
                correlativoEnvio = (decimal)repository.Table.ToList().Max(m => m.Correlativo);
                correlativoEnvio++;
            }
            catch (Exception ex)
            {
                correlativoEnvio = 1;
            }
            newCaja.correlativoEnvio = correlativoEnvio;

            shipmentCode = anio.ToString() + correlativoEnvio.ToString("000");
            newCaja.shipmentCode = shipmentCode;

            return newCaja;
        }

        public static Shipment GetShipmentById(int id)
        {
            repository = unitOfWork.Repository<Shipment>();

            var data = repository.Table.Where(mp => mp.Id == id).FirstOrDefault();

            return data;
        }

        public static List<Shipment> GetShipmentByFecha(DateTime fechaEnvio)
        {
            repository = unitOfWork.Repository<Shipment>();

            var data = repository.Table.Where(mp => mp.FechaEnvio == fechaEnvio).ToList();
            
            return data;
        }

        public static List<Shipment> GetShipmentCode()
        {
            repository = unitOfWork.Repository<Shipment>();

            var data = repository.Table.Where(s=>s.EstadoShipment=="A").ToList();
            data.Insert(0, new Shipment { ShipmentCode="", Id=0});
            return data;
        }

        public static Shipment GrabaInformacion(Shipment obj, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            repository = unitOfWork.Repository<Shipment>();

            try
            {
                if (obj.Id == 0)
                {
                    repository.Insert(obj);
                }
                else
                {
                    repository.Update(obj);
                }

                transaction.ReturnStatus = true;
            }
            catch (Exception ex)
            {
                transaction.ReturnStatus = false;
                transaction.ReturnMessage = "Error: " + ex.Message;
            }

            return obj;
        }

        public static List<EncPackingListDto> GetCajasByshipmentCode(string shipmentCode)
        {
            repositoryMC = unitOfWork.Repository<MovimientoCaja>();

            var data = (from mc in repositoryMC.Table
                        where mc.shipmentCode == shipmentCode
                        orderby mc.correlativo
                        select new EncPackingListDto
                        {
                            IdMovimiento = mc.Id,
                            cajaEnvio = mc.cajaEnvio,
                            fechaEnvio = mc.fechaEnvio,
                            pesoBruto = mc.pesoBruto.ToString(),
                            pesoNeto = mc.pesoNeto.ToString(),
                            shipTo = mc.shipTo,
                            palletEnvio = mc.pallet,
                            pesoPallet = mc.pesoPallet.ToString(),
                            bultoEnvio = mc.bulto,
                            pesoBulto = mc.pesoBulto.ToString()
                        }).ToList();

            return data;
        }

        public static void BorrarShipment(int id, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            repository = unitOfWork.Repository<Shipment>();

            try
            {
                var entity = GetShipmentById(id);
                repository.Delete(entity);

            }
            catch (Exception ex)
            {
                transaction.ReturnStatus = false;
                transaction.ReturnMessage = "Error: " + ex.Message;
            }
        }
        #endregion
    }
}
