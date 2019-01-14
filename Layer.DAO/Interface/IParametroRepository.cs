using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;

namespace Layer.DAO.Interface
{
    /// <summary>
    /// Interfaz con las operaciones del IParametro
    /// </summary>
    public interface IParametroRepository : IGenericRepository<Parametro>
    {
        #region Declaración
        List<Parametro> GetParametros();
        Parametro GetParametroById(int id);
        List<Parametro> GetParametroByTipo(string tipo);
        void Update(Parametro obj);
        void Insert(Parametro obj);
        #endregion
    }
}
