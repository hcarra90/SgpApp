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
    public static class EstadoBusiness
    {
        #region Declaración
        static readonly IEstadoRepository repository = new EstadoRepository();
        #endregion

        #region Métodos Publicos
        public static List<Estado> GetEstados(int idEmpresa)
        {
            return repository.GetEstados(idEmpresa);
        }

        public static void Insert(Estado obj)
        {
            repository.Insert(obj);
        }

        public static void Update(Estado obj)
        {
            repository.Update(obj);
        }
        #endregion
    }
}
