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
    public static class ProgramaExportBusiness
    {
        #region Declaración
        static readonly IProgramaExportRepository repository = new ProgramaExportRepository();
        #endregion

        #region Métodos Publicos
        public static List<ProgramaExport> GetProgramaExport(int idEmpresa)
        {
            return repository.GetProgramaExport(idEmpresa);
        }

        public static void Insert(ProgramaExport obj)
        {
            repository.Insert(obj);
        }

        public static void Update(ProgramaExport obj)
        {
            repository.Update(obj);
        }
        #endregion
    }
}
