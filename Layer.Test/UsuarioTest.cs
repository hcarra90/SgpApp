using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Layer.DAO.Interface;
using Layer.Entity;

namespace SeNegocia5.Test
{
    [TestClass]
    public class UsuarioTest
    {
        public IUsuarioRepository UsuarioRepository;

        [TestInitialize]
        public void Setup()
        {
            Usuario usuario = new Usuario
            {
                Id = 1,
                Nombres = "Nombres",
                Apellidos = "Apellidos",
                Login = "login",
                Password = "Password"
            };

            Mock<IUsuarioRepository> _mock = new Mock<IUsuarioRepository>();
            _mock.Setup(u => u.GetUsuario("usuario", "password")).Returns(usuario);

            UsuarioRepository = _mock.Object;
        }

        [TestMethod]
        public void validar()
        {
            Usuario usuario = UsuarioRepository.GetUsuario("usuario", "password");
            Assert.IsNotNull(usuario);
        }
    }
}
