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
    public static class CropBusiness
    {
        #region Declaración
        static readonly ICropRepository repository = new CropRepository();
        #endregion

        #region Métodos Publicos
        public static List<Crop> GetCrops(int idEmpresa)
        {
            return repository.GetCrops(idEmpresa);
        }

        public static void Insert(Crop obj)
        {
            repository.Insert(obj);
        }

        public static void Update(Crop obj)
        {
            repository.Update(obj);
        }
        #endregion
    }
}
