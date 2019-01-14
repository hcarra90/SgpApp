using Layer.DAO.Interface;
using Layer.DAO.Repositories;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;

namespace Layer.Business
{
    public static class InfoLocBusiness
    {
        #region Declaración
        static readonly IInfoLocRepository repository = new InfoLocRepository();
        #endregion

        #region Métodos Públicos
        public static List<InfoLoc> GetLocByCuartel(string cuartel)
        {
            return repository.GetLocByCuartel(cuartel);
        }

        public static InfoLoc GetLocById(int id)
        {
            return repository.GetLocById(id);
        }

        public static List<InfoLocDto> GetLocs()
        {
            return repository.GetLocs();
        }

        public static void Insert(InfoLoc obj)
        {
            repository.Insert(obj);
        }

        public static void Update(InfoLoc obj)
        {
            repository.Update(obj);
        }
        #endregion
    }
}
