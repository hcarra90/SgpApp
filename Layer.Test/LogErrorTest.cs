using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Layer.DAO.Interface;
using Layer.Entity;
using Layer.Entity.Dto.LogError;
using System;
using System.Collections.Generic;

namespace SeNegocia5.Test
{
    [TestClass]
    public class LogErrorTest
    {
        public ILogErrorRepository LogErrorRepository;

        [TestInitialize]
        public void Setup()
        {
            LogError logError = new LogError
            {
                Id = 1,
                Clase = "Clase Test 1",
                Metodo = "Metodo Test 1",
                Mensaje = "Mensaje Test 1",
                Traza = "Traza Test 1",
                NombreServidor = "localhost Test 1",
                IP = "127.0.0.1",
                Activo = true,
                UsuarioCreacionId = 1,
                FechaCreacion = DateTime.Now
            };

            LogErrorDTO logError2 = new LogErrorDTO
            {
                Id = 2,
                Clase = "Clase Test 2",
                Metodo = "Metodo Test 2",
                Mensaje = "Mensaje Test 2",
                Traza = "Traza Test 2",
                NombreServidor = "localhost Test 2",
                IP = "127.0.0.1",
                Activo = true,
                UsuarioCreacionId = 1,
                FechaCreacion = DateTime.Now
            };

            List<LogError> lsLogError = new List<LogError>();
            lsLogError.Add(logError);

            List<LogErrorDTO> listaLogError = new List<LogErrorDTO>();
            listaLogError.Add(logError2);

            Mock<ILogErrorRepository> _mock = new Mock<ILogErrorRepository>();
            _mock.Setup(l => l.GetAll()).Returns(lsLogError);
            _mock.Setup(l => l.GetLogError()).Returns(listaLogError);
            _mock.Setup(l => l.Add(It.IsAny<LogError>())).Returns(logError);

            LogErrorRepository = _mock.Object;
        }

        [TestMethod]
        public void agregar()
        {
            List<LogError> lista;
            LogError logError = new LogError
            {
                Id = 1,
                Clase = "Clase Test 3",
                Metodo = "Metodo Test 3",
                Mensaje = "Mensaje Test 3",
                Traza = "Traza Test 3",
                NombreServidor = "localhost Test 3",
                IP = "127.0.0.1",
                Activo = true,
                UsuarioCreacionId = 1,
                FechaCreacion = DateTime.Now
            };

            LogError respuesta = LogErrorRepository.Add(logError);
            LogErrorRepository.Save();
            lista = (List<LogError>)this.LogErrorRepository.GetAll();
            lista.Add(logError);

            Assert.IsNotNull(respuesta);
            Assert.AreEqual(2, lista.Count);
        }

        [TestMethod]
        public void listar()
        {
            List<LogErrorDTO> lista = (List<LogErrorDTO>)this.LogErrorRepository.GetLogError();
            Assert.IsNotNull(lista);
            Assert.AreEqual(1, lista.Count);
        }

        [TestMethod]
        public void listarTodo()
        {
            List<LogError> lista = (List<LogError>)this.LogErrorRepository.GetAll();
            Assert.IsNotNull(lista);
        }
    }
}
