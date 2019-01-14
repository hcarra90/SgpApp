using Layer.DAO.Interface;
using Layer.Entity;
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
        #endregion

        #region Constructores
        public ShipmentRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos

        public static Shipment GetShipmentById(int id)
        {
            repository = unitOfWork.Repository<Shipment>();
            var item = repository.Table.Where(mc => mc.Id == id).FirstOrDefault();
            return item;
        }

        /// <summary>
        /// Función que graba información de Eduid.
        /// </summary>
        /// <param name="obj">Euid</param>
        /// <returns>Devuelve un objeto de tipo Shipment.</returns>
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

        /// <summary>
        /// Función que elimina información de Eduid.
        /// </summary>
        /// <param name="id">Euid</param>
        /// <returns></returns>
        public static void Borrar(int id, out TransactionalInformation transaction)
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
