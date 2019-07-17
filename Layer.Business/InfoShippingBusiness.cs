using Layer.DAO;
using Layer.DAO.Interface;
using Layer.DAO.Repositories;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business
{
    public static class InfoShippingBusiness
    {
        #region Declaración
        //static readonly IInfoShippingRepository repository = new InfoShippingRepository();
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<InfoShipping> repository;
        //static readonly ICropRepository repository = new CropRepository();
        #endregion

        #region Métodos Públicos

        public static List<InfoShipping> GetAll()
        {
            repository = unitOfWork.Repository<InfoShipping>();
            InfoShipping info = new InfoShipping
            {
                shipTo=""
            };

            var data = repository.Table.ToList();

            data.Insert(0, info);
            return data;
        }

        public static List<InfoShipping> GetInfoByEmpresa(int idEmpresa)
        {
            repository = unitOfWork.Repository<InfoShipping>();
            var data = repository.Table.ToList();
            data = data.Where(p => p.id_empresa == idEmpresa).ToList();

            return data;
        }

        public static List<InfoShipping> GetShipToByCountry(string pais)
        {
            repository = unitOfWork.Repository<InfoShipping>();
            var data = repository.Table.Where(p=>p.country == pais).ToList();

            data.Insert(0, new InfoShipping { shipTo=""});
            return data;
        }

        public static List<InfoShipping> GetAddressByCountry(string pais)
        {
            repository = unitOfWork.Repository<InfoShipping>();
            var data = repository.Table.Where(p => p.country == pais).ToList();

            data.Insert(0, new InfoShipping { shipTo = "" });
            return data;
        }

        /// <summary>
        /// Función que obtiene información del ship to.
        /// </summary>
        /// <param name="shipTo"></param>
        /// <returns>InfoShipping</returns>
        public static InfoShipping GetInfoShipping(string shipTo)
        {
            //repository = unitOfWork.Repository<InfoShipping>();
            //return repository.GetInfoShipping(shipTo);
            var data = repository.Table.Where(r => r.shipTo == shipTo).FirstOrDefault();
            return data;
        }

        public static List<InfoShipping> GetAdressByShipTo(string shipTo)
        {
            repository = unitOfWork.Repository<InfoShipping>();
            var data = repository.Table.Where(p => p.shipTo == shipTo).ToList();
            data.Insert(0, new InfoShipping { shipTo = "" });

            return data;
        }
        public static InfoShipping GetInfoById(int id)
        {
            repository = unitOfWork.Repository<InfoShipping>();
            var data = repository.Table.Where(p => p.Id == id).FirstOrDefault();
            
            return data;
        }

        public static void GrabaDatos(InfoShipping obj)
        {
            //repository = unitOfWork.Repository<InfoShipping>();

            if (obj.Id == 0)
            {
                repository.Insert(obj);
            }
            else
            {
                repository.Update(obj);
            }
        }
        #endregion
    }
}
