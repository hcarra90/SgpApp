using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Interface
{
    public interface IEntryListRepository : IGenericRepository<EntryList>
    {
        bool EuidExist(string euid);
        List<string> GetEuidByJaula(string jaula, int idEmpresa);
        bool ValidateEuids(List<EntryList> data);
        List<EntryList> GetEuid(string cadena, string opcion);
        string GetMaxEuid();
        void Insert(EntryList obj);
    }
}
