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
    public static class InfoDryersBusiness
    {
        #region Declaración
        static readonly IInfoDryersRepository repository = new InfoDryersRepository();
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Función que obtiene información del info dryers.
        /// </summary>
        /// <param name=""></param>
        /// <returns>List</returns>
        public static List<InfoDryers> GetInfoDryers()
        {
            return repository.GetInfoDryers();
        }

        /// <summary>
        /// Función que obtiene información del info dryers.
        /// </summary>
        /// <param name=""></param>
        /// <returns>List</returns>
        public static List<InfoDryers> GetInfoDryerBox()
        {
            var data = repository.GetInfoDryers().Where(d => d.dryerBins != null).ToList();
            //var data2 = data.Where(d => d.dryerBins != null).ToList();
            return data;
        }

        public static Parametro GetParametros()
        {
            return repository.GetParametros();
        }

        public static InfoDryers GetSheller(string sheller)
        {
            return repository.GetSheller(sheller);
        }

        public static InfoDryers GetBin(string bin)
        {
            return repository.GetBin(bin);
        }

        public static InfoDryers GetDryerBox(string box)
        {
            return repository.GetDryerBox(box);
        }
        #endregion
    }
}
