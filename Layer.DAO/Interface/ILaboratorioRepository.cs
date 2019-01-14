using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Interface
{
    /// <summary>
    /// Interfaz con las operaciones de Laboratorio
    /// </summary>
    public interface ILaboratorioRepository : IGenericRepository<Laboratorio>
    {
        #region Declaración
        List<Laboratorio> GetLaboratorios(string estado, int currentPageNumber, int pageSize, string sortDirection, string sortExpression, out int totalRows);
        #endregion
    }
}
