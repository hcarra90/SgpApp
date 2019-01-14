using Layer.DAO.Interface;
using Layer.DAO.Repositories;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business
{
    public static class ClienteBusiness
    {
        #region Declaración
        static readonly IClienteRepository repository = new ClienteRepository();
        #endregion

        #region Métodos Publicos
        public static List<Cliente> GetClientes(int idEmpresa)
        {
            return repository.GetClientes(idEmpresa);
        }

        public static void Insert(Cliente obj)
        {
            repository.Insert(obj);
        }

        public static void Update(Cliente obj)
        {
            repository.Update(obj);
        }
        #endregion
    }
}
