using Layer.DAO.Interface;
using Layer.DAO.Repositories;
using Layer.Entity;
using System.Collections.Generic;

namespace Layer.Business
{
    public static class ConductorBusiness
    {
        #region Declaración
        static readonly IConductorRepository repository = new ConductorRepository();
        #endregion

        #region Métodos Publicos
        public static List<Conductor> GetConductores(int idEmpresa)
        {
            return repository.GetConductores(idEmpresa);
        }

        public static void Insert(Conductor obj)
        {
            repository.Insert(obj);
        }

        public static void Update(Conductor obj)
        {
            repository.Update(obj);
        }
        #endregion
    }
}
