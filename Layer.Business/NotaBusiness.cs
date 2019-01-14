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
    public static class NotaBusiness
    {
        #region -----Declaración-----
        static readonly INotaRepository repository = new NotaRepository();
        #endregion

        #region -----Métodos Públicos-----
        public static List<Nota> GetNotas(int idEmpresa)
        {
            return repository.GetNotas(idEmpresa);
        }

        public static void Insert(Nota obj)
        {
            repository.Insert(obj);
        }

        public static void Update(Nota obj)
        {
            repository.Update(obj);
        }

        #endregion
    }
}
