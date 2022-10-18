using CheckIn.Application.Dto.CheckIn;
using CheckIn.Application.Services;
using CheckIn.Application.UseCases.CheckIn;
using CheckIn.Application.UseCases.Reserva;
using CheckIn.Domain.Factories.CheckIn;
using CheckIn.Domain.Factories.Reserva;
using CheckIn.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Application.UseCases {
	public class CreateReservaHandler_Test {

		private readonly Mock<IReservaRepository> reservaRepository;
		private readonly Mock<ILogger<CreateReservaHandler>> logger;
		private readonly Mock<IReservaFactory> reservaFactory;
		private readonly Mock<IUnitOfWork> unitOfWork;
		private Guid id = Guid.NewGuid();
		private int nroReserva = 11;
		private DateTime hora = DateTime.Now;
		private Guid vueloId = Guid.NewGuid();
		private CheckIn.Domain.Model.Reserva.Reserva Reserva_Test;

		public CreateReservaHandler_Test() {
			reservaRepository = new Mock<IReservaRepository>();
			logger = new Mock<ILogger<CreateReservaHandler>>();
			reservaFactory = new Mock<IReservaFactory>();
			unitOfWork = new Mock<IUnitOfWork>();
			Reserva_Test = new ReservaFactory().Create(id, nroReserva, hora, vueloId);
		}

		[Fact]
		public void CrearReservaHandler_HandlerCorrectly() {
			reservaFactory.Setup(factory => factory.Create(id, nroReserva, hora, vueloId)).Returns(Reserva_Test);

			var objHandler = new CreateReservaHandler(
				reservaRepository.Object,
				logger.Object,
				reservaFactory.Object,
				unitOfWork.Object);
			var objRequest = new CreateReservaCommand(id, hora, vueloId);

			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			Assert.IsType<Guid>(result.Result);
		}

		[Fact]
		public void CrearReservaHandler_HandlerFail() {
			// Failling by returning null values
			var objHandler = new CreateReservaHandler(
				reservaRepository.Object,
				logger.Object,
				reservaFactory.Object,
				unitOfWork.Object);

			var objRequest = new CreateReservaCommand(id, hora, vueloId);

			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);

			logger.Verify(mock => mock.Log(
				It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
				It.Is<EventId>(eventId => eventId.Id == 0),
				It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Error al crear Reserva"),
				It.IsAny<Exception>(),
				It.IsAny<Func<It.IsAnyType, Exception, string>>())
			, Times.Once);
		}
	}
}
