using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;

namespace Layer.DAO.Interface
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        #region Declaración
        List<Cliente> GetClientes(int idEmpresa);
        void Update(Cliente obj);
        void Insert(Cliente obj);
        #endregion
    }
}
