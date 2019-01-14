using Layer.DAO.Interface;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Layer.DAO.Repositories
{
    public class MovimientoFloracionRepository : GenericRepository<DataContext, MovimientoFloracion>, IMovimientoFloracionRepository
    {
        #region -----Declaración-----
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<MovimientoFloracion> repository;
        #endregion

        #region -----Constructores-----
        public MovimientoFloracionRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region -----Métodos Públicos-----
        public List<MovimientoFloracion> Getfloraciones()
        {
            repository = unitOfWork.Repository<MovimientoFloracion>();
            var items = (from ta in repository.Table
                         select ta).ToList();

            return items;
        }

        public void Insert(MovimientoFloracion obj)
        {
            repository = unitOfWork.Repository<MovimientoFloracion>();
            repository.Insert(obj);
        }

        public void Update(MovimientoFloracion obj)
        {
            repository = unitOfWork.Repository<MovimientoFloracion>();
            repository.Update(obj);
        } 
        #endregion
    }
}
