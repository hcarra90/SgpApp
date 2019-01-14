using Layer.DAO.Interface;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Repositories
{
    public class NotaRepository : GenericRepository<DataContext, Nota>, INotaRepository
    {
        #region -----Declaración-----
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<Nota> repository;
        #endregion

        #region -----Constructores-----
        public NotaRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region -----Métodos Públicos-----
        public List<Nota> GetNotas(int idEmpresa)
        {
            repository = unitOfWork.Repository<Nota>();
            var items = (from ta in repository.Table
                         where ta.id_empresa == idEmpresa
                         select ta).ToList();
            items.Insert(0, new Nota { });

            return items;
        }

        public void Insert(Nota obj)
        {
            repository.Insert(obj);
        }

        public void Update(Nota obj)
        {
            repository.Update(obj);
        } 
        #endregion
    }
}
