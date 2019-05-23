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
    public class PalletBusiness
    {
        #region Declaración
        static readonly IPalletRepository repository = new PalletRepository();
        #endregion

        #region Métodos Publicos
        public static List<Pallet> GetPallet(int idEmpresa)
        {
            return repository.GetPallet(idEmpresa);
        }

        public static void Insert(Pallet obj)
        {
            repository.Insert(obj);
        }

        public static void Update(Pallet obj)
        {
            repository.Update(obj);
        }
        #endregion
    }
}
