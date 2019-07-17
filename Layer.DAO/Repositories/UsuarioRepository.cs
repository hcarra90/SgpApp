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
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<Parametro> repositoryP;
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
            string ambiente = db.Database.Connection.DataSource;

            string local = GetParametroBd(usuarioEncontrado.id_empresa, "Desa", "CNF");
            string qa = GetParametroBd(usuarioEncontrado.id_empresa, "Prod", "CNF");
            string prod = GetParametroBd(usuarioEncontrado.id_empresa, "Qa", "CNF");
            usuarioEncontrado.Servidor = ambiente;

            if (ambiente == local)
            {
                usuarioEncontrado.Ambiente = "DESARROLLO";
            }
            else if (ambiente == qa)
            {
                usuarioEncontrado.Ambiente = "QA";
            }
            else if (ambiente == prod)
            {
                usuarioEncontrado.Ambiente = "PRODUCCIÓN";
            }

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

        #region -----Datos Parametros-----
        private string GetParametroBd(int idEmpresa,string nombre,string tipo)
        {
            repositoryP = unitOfWork.Repository<Parametro>();
            var item = (from ta in repositoryP.Table
                             where ta.id_empresa == idEmpresa
                             && ta.Tipo == tipo && ta.Nombre == nombre
                             select ta).FirstOrDefault();

            return item.Valor;
        }
        #endregion
    }
}
