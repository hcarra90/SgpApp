using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;

namespace Layer.DAO.Interface
{
    /// <summary>
    /// Interfaz con las operaciones del InfoFarm
    /// </summary>
    public interface IInfoFarmRepository : IGenericRepository<InfoFarm>
    {
        #region Declaración
        List<InfoFarm> GetFarms();
        List<FarmDto> GetFarmsByEmpresa(int idEmpresa);
        List<FarmDto> GetSubFarmsByFarm(string codFarm);
        InfoFarm GetFarmById(int id);
        List<InfoFarm> GetFarmBySubFarm(string codFarm,string subFarm);
        void Update(InfoFarm obj);
        void Insert(InfoFarm obj);
        #endregion
    }
}
