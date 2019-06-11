using Layer.DAO.Interface;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Repositories
{
    public class VehiculoRepository : GenericRepository<DataContext, Vehiculo>, IVehiculoRepository
    {
        #region -----Declaración-----
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<Vehiculo> repository;
        #endregion

        #region -----Constructores-----
        public VehiculoRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region -----Métodos Públicos-----
        public List<Vehiculo> GetVehiculos(int idEmpresa)
        {
            repository = unitOfWork.Repository<Vehiculo>();
            var items = (from ta in repository.Table
                         where ta.id_empresa == idEmpresa
                         select ta).ToList();
            items.Insert(0, new Vehiculo { });

            return items;
        }

        public void Insert(Vehiculo obj)
        {
            repository.Insert(obj);
        }

        public void Update(Vehiculo obj)
        {
            repository.Update(obj);
        }
        #endregion
    }
}
