using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;
namespace Layer.DAO.Interface
{
    public interface ICropRepository : IGenericRepository<Crop>
    {
        #region Declaración
        List<Crop> GetCrops(int idEmpresa);
        void Update(Crop obj);
        void Insert(Crop obj);
        #endregion
    }
}
