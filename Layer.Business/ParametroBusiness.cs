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
    public static class ParametroBusiness
    {
        #region Declaración
        static readonly IParametroRepository repository = new ParametroRepository();
        #endregion

        #region Métodos Publicos

        public static Parametro GetParametroById(int id)
        {
            return repository.GetParametroById(id);
        }

        public static List<Parametro> GetParametroByTipo(string tipo)
        {
            return repository.GetParametroByTipo(tipo);
        }

        public static List<Parametro> GetParametros()
        {
            return repository.GetParametros();
        }

        public static void Insert(Parametro obj)
        {
            repository.Insert(obj);
        }

        public static void Update(Parametro obj)
        {
            repository.Update(obj);
        }
        #endregion
    }
}
