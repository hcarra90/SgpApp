using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;

namespace Layer.DAO.Interface
{
    /// <summary>
    /// Interfaz con las operaciones del Usuario
    /// </summary>
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        #region Declaración
        Usuario GetUsuario(string usuario, string password);
        Usuario GetUsuario(int id);
        List<Usuario> GetUsuarios();
        void BloqueaUsuario(string usuario);
        #endregion
    }
}
