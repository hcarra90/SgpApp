using Layer.DAO.Interface;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Repositories
{
    public class PalletRepository : GenericRepository<DataContext, Pallet>, IPalletRepository
    {
        #region Declaración
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<Pallet> repository;
        #endregion

        #region Constructores
        public PalletRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos
        public List<Pallet> GetPallet(int idEmpresa)
        {
            repository = unitOfWork.Repository<Pallet>();
            var items = (from ta in repository.Table
                         where ta.id_empresa == idEmpresa
                         select ta).ToList();
            items.Insert(0, new Pallet { });

            return items;
        }

        public void Update(Pallet obj)
        {
            repository.Update(obj);
        }

        public void Insert(Pallet obj)
        {
            repository.Insert(obj);
        }
        #endregion
    }
}
