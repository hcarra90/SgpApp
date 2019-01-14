using Layer.DAO.Interface;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Repositories
{
    public class CentroCostoRepository : GenericRepository<DataContext, CentroCosto>, ICentroCostoRepository
    {
        #region Declaración
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<CentroCosto> repository;
        #endregion

        #region Constructores
        public CentroCostoRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos
        public List<CentroCosto> GetCentroCosto(int idEmpresa)
        {
            repository = unitOfWork.Repository<CentroCosto>();
            var items = (from ta in repository.Table
                         where ta.id_empresa == idEmpresa
                         select ta).ToList();
            items.Insert(0, new CentroCosto { });

            return items;
        }

        public void Insert(CentroCosto obj)
        {
            repository.Insert(obj);
        }

        public void Update(CentroCosto obj)
        {
            repository.Update(obj);
        }
        #endregion
    }
}
