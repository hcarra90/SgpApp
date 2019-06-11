using Layer.DAO.Interface;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Repositories
{
    public class ConductorRepository : GenericRepository<DataContext, Conductor>, IConductorRepository
    {
        #region -----Declaración-----
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<Conductor> repository;
        #endregion

        #region -----Constructores-----
        public ConductorRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region -----Métodos Públicos-----
        public List<Conductor> GetConductores(int idEmpresa)
        {
            repository = unitOfWork.Repository<Conductor>();
            var items = (from ta in repository.Table
                         where ta.id_empresa == idEmpresa
                         select ta).ToList();
            items.Insert(0, new Conductor { });

            return items;
        }

        public void Insert(Conductor obj)
        {
            repository.Insert(obj);
        }

        public void Update(Conductor obj)
        {
            repository.Update(obj);
        }
        #endregion
    }
}
