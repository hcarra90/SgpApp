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
    public static class EntryListBusiness
    {
        #region Declaración
        static readonly IEntryListRepository repository = new EntryListRepository();
        #endregion

        #region Métodos Publicos

        public static bool EuidExist(string euid)
        {
            return repository.EuidExist(euid);
        }
        public static List<EntryList> GetEntryList(string cadena, string opcion)
        {
            return repository.GetEuid(cadena,opcion);
        }
        public static string GetMaxEuid()
        {
            return repository.GetMaxEuid();
        }

        public static bool ValidateEuids(List<EntryList> data)
        {
            return repository.ValidateEuids(data);
        }

        public static void InsertMasivo(List<EntryList> objs, EntryList obj)
        {
            repository.AddLista(objs, obj);
        }

        public static void Insert(EntryList obj)
        {
            repository.Insert(obj);
        }
        #endregion
    }
}
