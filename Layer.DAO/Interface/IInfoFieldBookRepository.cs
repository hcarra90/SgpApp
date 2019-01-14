using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;

namespace Layer.DAO.Interface
{
    /// <summary>
    /// Interfaz con las operaciones del InfoFieldBook
    /// </summary>
    public interface IInfoFieldBookRepository : IGenericRepository<InfoFieldBook>
    {
        #region Declaración
        List<InfoFieldBook> GetEuid(string cadena, string opcion);
        InfoFieldBook GetIndEuid(string indEuid, string euid);
        string GetSecuenciaIndEuid(string euid);
        List<ProjectLeadDto> GetProjectLead();
        List<AnioDto> GetAnio();
        List<CCDto> GetCc();
        List<ExpNameDto> GetExpName();
        InfoFieldBook GetRowById(int id);
        bool ValidateEuids(List<SplitEuidDto> data);
        void Update(InfoFieldBook movimiento);
        void Insert(InfoFieldBook movimiento);
        bool ValidateIndEuids(List<InfoFieldBook> data);
        #endregion
    }
}
