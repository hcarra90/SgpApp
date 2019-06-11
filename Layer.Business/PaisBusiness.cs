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
    public static class PaisBusiness
    {
        #region -----Declaración-----
        static readonly IPaisRepository repository = new PaisRepository();
        #endregion

        #region -----Métodos Publicos-----
        public static List<Pais> GetPais(int idEmpresa)
        {
            return repository.GetPais(idEmpresa);
        }

        public static void Insert(Pais obj)
        {
            repository.Insert(obj);
        }

        public static void Update(Pais obj)
        {
            repository.Update(obj);
        }
        #endregion
    }
}
