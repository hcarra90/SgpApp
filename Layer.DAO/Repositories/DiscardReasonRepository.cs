using Layer.DAO.Interface;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Repositories
{
    public class DiscardReasonRepository : GenericRepository<DataContext, DiscardReason>, IDiscardReasonRepository
    {
        #region Declaración
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<DiscardReason> repository;
        #endregion

        #region Constructores
        public DiscardReasonRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos
        public List<DiscardReason> GetAllData()
        {
            repository = unitOfWork.Repository<DiscardReason>();
            var item = repository.Table.ToList();
            return item;
        }
        #endregion

    }
}
