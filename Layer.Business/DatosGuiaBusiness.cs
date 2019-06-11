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
    public static class DatosGuiaBusiness
    {
        #region Declaración
        static readonly IDatosGuiaRepository repository = new DatosGuiaRepository();
        #endregion

        #region -----Métodos Públicos-----

        public static List<DatosGuia> GetData(int idGuia = 0)
        {
            return repository.GetData(idGuia);
        }

        public static void Insert(DatosGuia obj)
        {
            repository.Insert(obj);
        }

        public static void InsertBulk(List<DatosGuia> entities)
        {
            repository.InsertBulk(entities);
        }
        #endregion
    }
}
