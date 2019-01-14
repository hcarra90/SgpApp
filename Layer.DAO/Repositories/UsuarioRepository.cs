using Layer.DAO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using Layer.Entity;
using Layer.Entity.Dto;
using System.Linq.Expressions;

namespace Layer.DAO.Repositories
{
    /// <summary>
    /// Clase que implementa las operaciones del usuario
    /// </summary>
    public class UsuarioRepository : GenericRepository<DataContext, Usuario>, IUsuarioRepository
    {
        #region Declaración
        readonly DataContext db;
        #endregion

        #region Constructores
        public UsuarioRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Validar s usuario existe en la base de datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns>Usuario</returns>
        public Usuario GetUsuario(string usuario, string password)
        {
            var usuarioEncontrado = db.Usuario.Include("Perfil").Where(u => u.nombre_usuario == usuario && u.password == password).FirstOrDefault();

            return usuarioEncontrado;
        }

        /// <summary>
        /// Función que valida si el usuario existe.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Usuario</returns>
        public Usuario GetUsuario(int id)
        {
            return null;
        }

        public List<Usuario> GetUsuarios()
        {
            var usuarios = db.Usuario.ToList();
            return usuarios;
        }
        /// <summary>
        /// Bloquear usuario
        /// </summary>
        /// <param name="usuario"></param>
        public void BloqueaUsuario(string usuario)
        {
            
        }
        #endregion
    }
}
