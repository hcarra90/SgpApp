using Layer.DAO.Interface;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Repositories
{
    public class ShipmentRepository: GenericRepository<DataContext, Shipment>, IShipmentRepository
    {
        #region Declaración
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<Shipment> repository;
        private static Repository<MovimientoCaja> repositoryMC;
        #endregion

        #region Constructores
        public ShipmentRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos

        public Shipment GetShipmentById(int id)
        {
            repository = unitOfWork.Repository<Shipment>();
            var item = repository.Table.Where(mc => mc.Id == id).FirstOrDefault();
            return item;
        }

        public List<int> GetCajasByEnvase(string codigo)
        {
            repositoryMC = unitOfWork.Repository<MovimientoCaja>();

            var data = (from mc in repositoryMC.Table
                        where (mc.pallet == codigo || mc.bulto ==codigo)
                        select mc.Id).ToList();

            return data;
        }

        public List<EncPackingListDto> GetCajasByshipmentCode(string shipmentCode)
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

        /// <summary>
        /// Función que graba información de Eduid.
        /// </summary>
        /// <param name="obj">Euid</param>
        /// <returns>Devuelve un objeto de tipo Shipment.</returns>
        public Shipment GrabaInformacion(Shipment obj, out TransactionalInformation transaction)
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

        /// <summary>
        /// Función que elimina información de Eduid.
        /// </summary>
        /// <param name="id">Euid</param>
        /// <returns></returns>
        public void BorrarShipment(int id, out TransactionalInformation transaction)
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

        public CajaEnvioDto GetCorrelativoEnvio(int anio)
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
        public List<Shipment> GetShipmentByFecha(DateTime fechaEnvio)
        {
            repository = unitOfWork.Repository<Shipment>();

            var data = repository.Table.Where(mp => mp.FechaEnvio == fechaEnvio).ToList();

            return data;
        }

        public List<Shipment> GetShipmentCode()
        {
            repository = unitOfWork.Repository<Shipment>();

            var data = repository.Table.Where(s => s.EstadoShipment == "A").ToList();
            data.Insert(0, new Shipment { ShipmentCode = "", Id = 0 });
            return data;
        }
        #endregion
    }
}
