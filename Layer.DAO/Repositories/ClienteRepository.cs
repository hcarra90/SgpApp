using Layer.DAO.Interface;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Repositories
{
    public class ClienteRepository : GenericRepository<DataContext, Cliente>, IClienteRepository
    {
        #region Declaración
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<Cliente> repository;
        #endregion

        #region Constructores
        public ClienteRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos
        public List<Cliente> GetClientes(int idEmpresa)
        {
            repository = unitOfWork.Repository<Cliente>();
            var items = (from ta in repository.Table
                         where ta.id_empresa == idEmpresa
                         select ta).ToList();
            items.Insert(0, new Cliente { });

            return items;
        }

        public void Insert(Cliente obj)
        {
            repository.Insert(obj);
        }

        public void Update(Cliente obj)
        {
            repository.Update(obj);
        }
        #endregion

    }
}
