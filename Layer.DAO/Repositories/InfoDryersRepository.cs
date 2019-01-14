using Layer.DAO.Interface;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Repositories
{
    /// <summary>
    /// Clase que implementa las operaciones de la tabla InfoDryers
    /// </summary>
    public class InfoDryersRepository : GenericRepository<DataContext, InfoDryers>, IInfoDryersRepository
    {
        #region Declaración
        readonly DataContext db;
        #endregion

        #region Constructores
        public InfoDryersRepository()
        {
            this.db = new DataContext();
        }

        /// <summary>
        /// Función que obtiene información del info dryers.
        /// </summary>
        /// <param name=""></param>
        /// <returns>List</returns>
        public List<InfoDryers> GetInfoDryers()
        {
            var data = (from ue in db.InfoDryers
                        select ue).ToList();

            data.Insert(0, new InfoDryers { dryerBins = "", Id = 0, plasticBins = "", shellers = "" });
            return data;
        }

        public Parametro GetParametros()
        {
            var data = (from ue in db.Parametro
                        select ue).SingleOrDefault();

            return data;
        }

        public InfoDryers GetSheller(string sheller)
        {
            var data = (from mc in db.InfoDryers
                        where mc.shellers == sheller
                        select mc).FirstOrDefault();
            return data;
        }

        public InfoDryers GetBin(string bin)
        {
            var data = (from mc in db.InfoDryers
                        where mc.plasticBins == bin
                        select mc).FirstOrDefault();
            return data;
        }

        public InfoDryers GetDryerBox(string box)
        {
            var data = (from mc in db.InfoDryers
                        where mc.dryerBins == box
                        select mc).FirstOrDefault();
            return data;
        }
        #endregion

    }
}
