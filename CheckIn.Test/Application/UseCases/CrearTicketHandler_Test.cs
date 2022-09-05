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

namespace CheckIn.Test.Application.UseCases {
	public class CrearTicketHandler_Test {
		private readonly Mock<ITicketRepository> ticketRepository;
		private readonly Mock<ILogger<CreateTicketHandler>> logger;
		private readonly Mock<ITicketFactory> ticketFactory;
		private readonly Mock<IUnitOfWork> unitOfWork;
		private int nroTicket = 7;
		private DateTime horaReserva = DateTime.Now;
		private Guid vueloId = Guid.NewGuid();
		private Ticket Ticket_Test;

		public CrearTicketHandler_Test() {
			ticketRepository = new Mock<ITicketRepository>();
			logger = new Mock<ILogger<CreateTicketHandler>>();
			ticketFactory = new Mock<ITicketFactory>();
			unitOfWork = new Mock<IUnitOfWork>();
			Ticket_Test = new TicketFactory().Create(nroTicket, horaReserva, vueloId);
		}

		[Fact]
		public void CrearTicketHandler_HandlerCorrectly() {
			ticketFactory.Setup(factory => factory.Create(nroTicket, horaReserva, vueloId)).Returns(Ticket_Test);

			var objHandler = new CreateTicketHandler(
				ticketRepository.Object,
				logger.Object,
				ticketFactory.Object,
				unitOfWork.Object);
			var objRequest = new CreateTicketCommand(horaReserva, vueloId);

			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			Assert.IsType<Guid>(result.Result);
		}

		[Fact]
		public void CrearTicketHandler_HandlerFail() {
			// Failling by returning null values
			var objHandler = new CreateTicketHandler(
				ticketRepository.Object,
				logger.Object,
				ticketFactory.Object,
				unitOfWork.Object);

			var objRequest = new CreateTicketCommand(horaReserva, vueloId);

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
