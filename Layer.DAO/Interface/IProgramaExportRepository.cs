using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;

namespace Layer.DAO.Interface
{
    public interface IProgramaExportRepository : IGenericRepository<ProgramaExport>
    {
        #region Declaración
        List<ProgramaExport> GetProgramaExport(int idEmpresa);
        void Update(ProgramaExport obj);
        void Insert(ProgramaExport obj);
        #endregion
    }
}
