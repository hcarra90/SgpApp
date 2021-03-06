﻿using Layer.DAO.Interface;
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
        static readonly IInfoShippingRepository repository = new InfoShippingRepository();
        #endregion

        #region Métodos Públicos

        public static List<InfoShipping> GetAll()
        {
            InfoShipping info = new InfoShipping
            {
                shipTo=""
            };

            var data = repository.GetAll().ToList();

            data.Insert(0, info);
            return data;
        }

        public static List<InfoShipping> GetShipToByCountry(string pais)
        {
            var data = repository.GetAll().Where(p=>p.country == pais).ToList();

            data.Insert(0, new InfoShipping { shipTo=""});
            return data;
        }

        public static List<InfoShipping> GetAddressByCountry(string pais)
        {
            var data = repository.GetAll().Where(p => p.country == pais).ToList();

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
            return repository.GetInfoShipping(shipTo);
        }

        public static List<InfoShipping> GetAdressByShipTo(string shipTo)
        {
            var data = repository.GetAll().Where(p => p.shipTo == shipTo).ToList();
            data.Insert(0, new InfoShipping { shipTo = "" });

            return data;
        }
        #endregion
    }
}
