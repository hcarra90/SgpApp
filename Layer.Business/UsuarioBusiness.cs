using Layer.DAO.Interface;
using Layer.DAO.Repositories;
using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;

namespace Layer.Business
{
    public static class UsuarioBusiness
    {
        #region Declaración
        static readonly IUsuarioRepository repository = new UsuarioRepository();
        #endregion

        #region Métodos Públicos
        ///<summary>
        ///Función que valida si el usuario existe.
        ///</summary>
        ///<return>Devuelve un objeto de tipo Usuario.</return>
        ///<param name='usuario'>Nombre de usuario.</param>
        ///<param name='password'>Password del usuario.</param>
        public static Usuario ValidaUsuario(string usuario, string password, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            Usuario user = new Usuario();

            try
            {
                user = repository.GetUsuario(usuario, password);
                transaction.IsAuthenicated=true;
            }
            catch (System.Exception ex)
            {
                string errorMessage = string.Empty;
                if (ex.InnerException != null)
                {
                    errorMessage = ex.Message + " " + ex.InnerException.ToString();
                }
                else
                {
                    errorMessage = ex.Message + " ";
                }
                transaction.ReturnMessage=errorMessage;
                transaction.IsAuthenicated = false;
            }

            return user;
        }

        /// <summary>
        /// Función que valida si el usuario existe.
        /// </summary>
        /// <param name="id">Identificador del Usuario</param>
        /// <returns>Devuelve un objeto de tipo Usuario.</returns>
        public static Usuario ValidaUsuario(int id)
        {
            return repository.GetUsuario(id);
        }

        /// <summary>
        /// Función que bloquea el usuario
        /// </summary>
        /// <param name="usuario"></param>
        public static void BloquearUsuario(string usuario)
        {
            repository.BloqueaUsuario(usuario);
        }

        public static List<Usuario> GetUsuarios()
        {
            return repository.GetUsuarios();
        }
        #endregion
    }
}
