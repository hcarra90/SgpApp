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
    public static class TipoAgroBusiness
    {
        #region Declaración
        static readonly ITipoAgroRepository repository = new TipoAgroRepository();
        #endregion

        #region Métodos Publicos
        public static List<TipoAgro> GetDatos(int idEmpresa)
        {
            return repository.GetDatos(idEmpresa);
        }
        #endregion
    }
}
