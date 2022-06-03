using CheckIn.Application.UseCases.Ticket;
using CheckIn.Domain.Factories.Ticket;
using CheckIn.Domain.Model.Ticket;
using CheckIn.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Pedidos.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Application.UseCases
{
    public class CrearTicketHandler_Test
    {
        private readonly Mock<ITicketRepository> asientoRepository;
        private readonly Mock<ILogger<CrearTicketHandler>> logger;
        private readonly Mock<ITicketFactory> asientoFactory;
        private readonly Mock<IUnitOfWork> unitOfWork;
        private DateTime horaReserva = DateTime.Now;
        private Ticket Ticket_Test;

        public CrearTicketHandler_Test()
        {
            asientoRepository = new Mock<ITicketRepository>();
            logger = new Mock<ILogger<CrearTicketHandler>>();
            asientoFactory = new Mock<ITicketFactory>();
            unitOfWork = new Mock<IUnitOfWork>();
            Ticket_Test = new TicketFactory().Create(horaReserva);
        }

        [Fact]
        public void CrearTicketHandler_HandlerCorrectly()
        {
            asientoFactory.Setup(factory => factory.Create(horaReserva)).Returns(Ticket_Test);

            var objHandler = new CrearTicketHandler(
                asientoRepository.Object,
                logger.Object,
                asientoFactory.Object,
                unitOfWork.Object);
            var objRequest = new CrearTicketComand(horaReserva);

            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);
            Assert.IsType<Guid>(result.Result);
        }

        [Fact]
        public void CrearTicketHandler_HandlerFail()
        {
            // Failling by returning null values
            var objHandler = new CrearTicketHandler(
                asientoRepository.Object,
                logger.Object,
                asientoFactory.Object,
                unitOfWork.Object);

            var objRequest = new CrearTicketComand(horaReserva);

            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);

            logger.Verify(mock => mock.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                It.Is<EventId>(eventId => eventId.Id == 0),
                It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Error al crear Ticket"),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>())
            , Times.Once);
        }
    }
}
