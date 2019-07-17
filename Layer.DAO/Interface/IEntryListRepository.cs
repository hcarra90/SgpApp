using Layer.Entity;
using Layer.Entity.Dto;
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
        List<CropDto> GetTipoConversion(int idEmpresa, string location);
        bool ValidateEuids(List<EntryList> data);
        List<EntryList> GetEuid(string cadena, string opcion);
        List<EntryList> GetDataByYearLoc(int year, string location);
        EntryList GetEuidById(int id);
        List<DataGuiaDespachoDto> GetDataGuiaDespacho(string location);
        string GetMaxEuid();
        void Insert(EntryList obj);
        void Update(EntryList obj);
        void InsertBulk(List<EntryList> entities);
        List<ListaComboDto> GetAnio();
        List<ListaComboDto> GetCountry();
        List<ListaComboDto> GetLocation();
        List<ListaComboDto> GetExperiment();
        List<ListaComboDto> GetProjectLead();
        List<ListaComboDto> GetCrop();
        List<ListaComboDto> GetClient();
        List<ListaComboDto> GetCc();
    }
}
