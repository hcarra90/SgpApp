using Layer.DAO.Interface;
using Layer.DAO.Repositories;
using Layer.Entity;
using Layer.Entity.Dto;
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
        public static List<Pallet> GetPallet(int idEmpresa,bool grilla)
        {
            var pallets= repository.GetPallet(idEmpresa);
            if (!grilla)
            {
                pallets.Insert(0, new Pallet { });
            }
            
            return pallets;
        }

        public static EnvaseSecuenciaDto GetSecuenciaPallet(int idEmpresa, int idTipo)
        {
            return repository.GetSecuenciaPallet(idEmpresa, idTipo);
        }

        public static void Insert(Pallet obj)
        {
            repository.Insert(obj);
        }

        public static void Update(Pallet obj)
        {
            repository.Update(obj);
        }
        public static void Delete(Pallet obj)
        {
            repository.Delete(obj);
        }
        public static void Borrar(int id, out TransactionalInformation transaction)
        {
            repository.Borrar(id, out transaction);
        }
        #endregion
    }
}
