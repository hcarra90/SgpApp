using Layer.DAO.Interface;
using Layer.DAO.Repositories;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;

namespace Layer.Business
{
    public static class InfoFarmBusiness
    {
        #region Declaración
        static readonly IInfoFarmRepository repository = new InfoFarmRepository();
        #endregion

        #region Métodos Públicos
        
        public static InfoFarm GetFarmById(int id)
        {
            return repository.GetFarmById(id);
        }

        public static List<InfoFarm> GetFarmBySubFarm(string codFarm, string subFarm)
        {
            return repository.GetFarmBySubFarm(codFarm, subFarm);
        }

        public static List<InfoFarm> GetFarms()
        {
            return repository.GetFarms();
        }

        public static void Insert(InfoFarm obj)
        {
            repository.Insert(obj);
        }

        public static void Update(InfoFarm obj)
        {
            repository.Update(obj);
        }

        public static List<FarmDto> GetFarmsByEmpresa(int idEmpresa)
        {
            return repository.GetFarmsByEmpresa(idEmpresa);
        }

        public static List<FarmDto> GetSubFarmsByFarm(string codFarm)
        {
            return repository.GetSubFarmsByFarm(codFarm);
        }
        #endregion
    }
}
