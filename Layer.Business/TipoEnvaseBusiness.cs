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
    public static class TipoEnvaseBusiness
    {
        #region -----Declaración-----
        static readonly ITipoEnvaseRepository repository = new TipoEnvaseRepository();
        #endregion

        #region -----Métodos Publicos-----
        public static List<TipoEnvase> GetTipoEnvase(int idEmpresa)
        {
            return repository.GetTipoEnvase(idEmpresa);
        }

        public static void Insert(TipoEnvase obj)
        {
            repository.Insert(obj);
        }

        public static void Update(TipoEnvase obj)
        {
            repository.Update(obj);
        }
        #endregion
    }
}
