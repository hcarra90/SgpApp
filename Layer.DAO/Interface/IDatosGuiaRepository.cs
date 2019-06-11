using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Interface
{
    /// <summary>
    /// Interfaz con las operaciones del DatosGuia
    /// </summary>
    public interface IDatosGuiaRepository : IGenericRepository<DatosGuia>
    {
        #region Declaración
        List<DatosGuia> GetData(int idGuia=0);
        void Insert(DatosGuia obj);
        void InsertBulk(List<DatosGuia> entities);
        #endregion
    }
}
