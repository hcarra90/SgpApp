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
    /// Clase que implementa las operaciones de la tabla InfoShipping
    /// </summary>
    public class InfoShippingRepository : GenericRepository<DataContext, InfoShipping>, IInfoShippingRepository
    {
        #region Declaración
        readonly DataContext db;
        #endregion

        #region Constructores
        public InfoShippingRepository()
        {
            this.db = new DataContext();
        }

        /// <summary>
        /// Función que obtiene información del ship to.
        /// </summary>
        /// <param name="shipTo"></param>
        /// <returns>InfoShipping</returns>
        public InfoShipping GetInfoShipping(string shipTo)
        {
            var data = (from ue in db.InfoShipping
                                  where ue.shipTo == shipTo
                                  select ue).FirstOrDefault();

            return data;
        }
        #endregion
    }
}
