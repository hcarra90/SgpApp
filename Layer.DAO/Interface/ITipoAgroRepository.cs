using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;

namespace Layer.DAO.Interface
{
    /// <summary>
    /// Interfaz con las operaciones del ITipoAgro
    /// </summary>
    public interface ITipoAgroRepository : IGenericRepository<TipoAgro>
    {
        #region Declaración
        List<TipoAgro> GetDatos(int idEmpresa);
        #endregion
    }
}
