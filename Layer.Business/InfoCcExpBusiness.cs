using Layer.DAO.Interface;
using Layer.DAO.Repositories;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;

namespace Layer.Business
{
    public static class InfoCcExpBusiness
    {
        #region Declaración
        static readonly IInfoCcExpRepository repository = new InfoCcExpRepository();
        #endregion

        #region Métodos Públicos
        public static List<CentroCostoExperimento> GetCCByLoc(int idLoc)
        {
            return repository.GetCCByLoc(idLoc);
        }

        public static CentroCostoExperimento GetCCExpById(int id)
        {
            return repository.GetCCExpById(id);
        }

        public static List<CentroCostoExperimento> GetCcs()
        {
            return repository.GetCcs();
        }

        public static void Insert(CentroCostoExperimento obj)
        {
            repository.Insert(obj);
        }

        public static void Update(CentroCostoExperimento obj)
        {
            repository.Update(obj);
        }
        #endregion
    }
}
