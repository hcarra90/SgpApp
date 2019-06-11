using Layer.DAO.Interface;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Repositories
{
    public class TipoEnvaseRepository : GenericRepository<DataContext, TipoEnvase>, ITipoEnvaseRepository
    {
        #region Declaración
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<TipoEnvase> repository;
        #endregion

        #region Constructores
        public TipoEnvaseRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos
        public List<TipoEnvase> GetTipoEnvase(int idEmpresa)
        {
            repository = unitOfWork.Repository<TipoEnvase>();
            var items = (from ta in repository.Table
                         where ta.id_empresa == idEmpresa
                         select ta).ToList();
            items.Insert(0, new TipoEnvase { });

            return items;
        }

        public void Insert(TipoEnvase obj)
        {
            repository.Insert(obj);
        }

        public void Update(TipoEnvase obj)
        {
            repository.Update(obj);
        }
        #endregion
    }
}
