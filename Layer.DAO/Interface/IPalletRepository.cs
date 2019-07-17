using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;

namespace Layer.DAO.Interface
{
    public interface IPalletRepository : IGenericRepository<Pallet>
    {
        #region Declaración
        List<Pallet> GetPallet(int idEmpresa);
        EnvaseSecuenciaDto GetSecuenciaPallet(int idEmpresa, int idTipo);
        void Update(Pallet obj);
        void Insert(Pallet obj);
        void Borrar(int id, out TransactionalInformation transaction);
        #endregion
    }
}
