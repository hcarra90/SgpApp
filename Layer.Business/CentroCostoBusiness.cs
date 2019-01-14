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
    public static class CentroCostoBusiness
    {
        #region Declaración
        static readonly ICentroCostoRepository repository = new CentroCostoRepository();
        #endregion

        #region Métodos Publicos
        public static List<CentroCosto> GetCentroCosto(int idEmpresa)
        {
            return repository.GetCentroCosto(idEmpresa);
        }

        public static void Insert(CentroCosto obj)
        {
            repository.Insert(obj);
        }

        public static void Update(CentroCosto obj)
        {
            repository.Update(obj);
        }
        #endregion
    }
}
