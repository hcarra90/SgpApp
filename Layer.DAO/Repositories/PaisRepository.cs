using Layer.DAO.Interface;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Repositories
{
    public class PaisRepository : GenericRepository<DataContext, Pais>, IPaisRepository
    {
        #region Declaración
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<Pais> repository;
        #endregion

        #region Constructores
        public PaisRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos
        public List<Pais> GetPais(int idEmpresa)
        {
            repository = unitOfWork.Repository<Pais>();
            var items = (from ta in repository.Table
                         where ta.id_empresa == idEmpresa
                         select ta).ToList();
            items.Insert(0, new Pais { });

            return items;
        }

        public void Insert(Pais obj)
        {
            repository.Insert(obj);
        }

        public void Update(Pais obj)
        {
            repository.Update(obj);
        }
        #endregion
    }
}
