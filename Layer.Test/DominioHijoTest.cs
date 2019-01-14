using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Layer.DAO.Interface;
using Layer.Entity.Dto;
using System.Collections.Generic;

namespace SeNegocia5.Test
{
    [TestClass]
    public class DominioHijoTest
    {
        IDominioHijoRepository DominioHijoRepository;

        [TestInitialize]
        public void Setup()
        {
            TipoSolicitudDTO dominioHijo = new TipoSolicitudDTO
            {
                Id = 1,
                Nombre = "valor 1"
            };

            List<TipoSolicitudDTO> listaTipoSolicitud = new List<TipoSolicitudDTO>();
            listaTipoSolicitud.Add(dominioHijo);

            Mock<IDominioHijoRepository> _mock = new Mock<IDominioHijoRepository>();
            _mock.Setup(d => d.GetTiposSolicitud()).Returns(listaTipoSolicitud);

            DominioHijoRepository = _mock.Object;
        }

        [TestMethod]
        public void tipoSolicitud()
        {
            List<TipoSolicitudDTO> lista = (List<TipoSolicitudDTO>)this.DominioHijoRepository.GetTiposSolicitud();
            Assert.IsNotNull(lista);
            Assert.AreEqual(1, lista.Count);
        }
    }
}
