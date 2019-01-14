using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;

namespace Layer.DAO.Interface
{
    public interface INotaRepository : IGenericRepository<Nota>
    {
        #region Declaración
        List<Nota> GetNotas(int idEmpresa);
        void Update(Nota obj);
        void Insert(Nota obj);
        #endregion
    }
}
