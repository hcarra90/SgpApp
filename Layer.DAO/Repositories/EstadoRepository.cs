using Layer.DAO.Interface;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Repositories
{
    public class EstadoRepository : GenericRepository<DataContext, Estado>, IEstadoRepository
    {
        #region Declaración
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<Estado> repository;
        #endregion

        #region Constructores
        public EstadoRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos
        public List<Estado> GetEstados(int idEmpresa)
        {
            repository = unitOfWork.Repository<Estado>();
            var items = (from ta in repository.Table
                         where ta.id_empresa == idEmpresa
                         select ta).ToList();
            items.Insert(0, new Estado { });

            return items;
        }

        public void Insert(Estado obj)
        {
            repository.Insert(obj);
        }

        public void Update(Estado obj)
        {
            repository.Update(obj);
        } 
        #endregion
    }
}
