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
    public static class MovimientoFloracionBusiness
    {
        #region -----Declaración-----
        static readonly IMovimientoFloracionRepository repository = new MovimientoFloracionRepository();
        #endregion

        #region -----Métodos Públicos-----
        public static List<MovimientoFloracion> GetFloraciones()
        {
            return repository.Getfloraciones();
        }

        public static void Insert(MovimientoFloracion obj)
        {
            repository.Insert(obj);
        }

        public static void Update(MovimientoFloracion obj)
        {
            repository.Update(obj);
        }

        #endregion
    }
}
