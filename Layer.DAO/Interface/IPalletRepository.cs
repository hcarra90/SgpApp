using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;

namespace Layer.DAO.Interface
{
    public interface IPalletRepository : IGenericRepository<Pallet>
    {
        #region Declaración
        List<Pallet> GetPallet(int idEmpresa);
        void Update(Pallet obj);
        void Insert(Pallet obj);
        #endregion
    }
}
