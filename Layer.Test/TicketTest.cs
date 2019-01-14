using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Layer.DAO.Repositories;
using Layer.Entity;
using Layer.DAO.Interface;
using System.Collections.Generic;
using Layer.Entity.Dto;

namespace SeNegocia5.Test
{
    [TestClass]
    public class TicketTest
    {
        public ITicketRepository TicketRepository;

        [TestInitialize]
        public void Setup()
        {
            var ticket = new Ticket()
            {
                TipoSolicitudId = 108,
                Observacion = "Test1"
            };

            var list = new List<TicketDTO>();
            list.Add(new TicketDTO
            {
                TipoSolicitudId = 1,
                Observacion = "Test"
            });

            var listTicket = new List<Ticket>();
            listTicket.Add(new Ticket
            {
                TipoSolicitudId = 1,
                Observacion = "Test"
            });

            Mock<ITicketRepository> _mock = new Mock<ITicketRepository>();

            _mock.Setup(mr => mr.GetAll()).Returns(listTicket);
            _mock.Setup(mr => mr.GetTickets()).Returns(list);
            _mock.Setup(t => t.Add(It.IsAny<Ticket>())).Returns(ticket);

            TicketRepository = _mock.Object;
        }

        [TestMethod]
        public void TestMethod1()
        {
            List<Ticket> testTickets = (List<Ticket>)this.TicketRepository.GetAll();

            Assert.IsNotNull(testTickets);
            Assert.AreEqual(1, testTickets.Count);
        }

        [TestMethod]
        public void canAdd()
        {
            List<Ticket> testTickets;
            Ticket ticketNuevo = new Ticket()
            {
                TipoSolicitudId = 109,
                Observacion = "Test2",
                FechaCreacion = DateTime.Now,
                UsuarioCreacionId = 1
            };

            TicketRepository.Add(ticketNuevo);
            TicketRepository.Save();
            testTickets = (List<Ticket>)this.TicketRepository.GetAll();
            testTickets.Add(ticketNuevo);

            Assert.AreEqual(2, testTickets.Count);
        }
    }
}
