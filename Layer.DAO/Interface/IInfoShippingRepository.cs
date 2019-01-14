using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Interface
{
    /// <summary>
    /// Interfaz con las operaciones del InfoShipping
    /// </summary>
    public interface IInfoShippingRepository : IGenericRepository<InfoShipping>
    {
        InfoShipping GetInfoShipping(string shipTo);
    }
}
