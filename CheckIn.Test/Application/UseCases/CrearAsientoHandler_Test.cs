using CheckIn.Application.UseCases.Avion;
using CheckIn.Domain.Factories.Avion;
using CheckIn.Domain.Model.Avion;
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
	public class CrearAsientoHandler_Test {
		private readonly Mock<IAsientoRepository> asientoRepository;
		private readonly Mock<ILogger<CrearAsientoHandler>> logger;
		private readonly Mock<IAsientoFactory> asientoFactory;
		private readonly Mock<IUnitOfWork> unitOfWork;
		private int fila = 11;
		private string letra = "D";
		private int esPrioridad = 1;
		private Asiento Asiento_Test;

		public CrearAsientoHandler_Test() {
			asientoRepository = new Mock<IAsientoRepository>();
			logger = new Mock<ILogger<CrearAsientoHandler>>();
			asientoFactory = new Mock<IAsientoFactory>();
			unitOfWork = new Mock<IUnitOfWork>();
			Asiento_Test = new AsientoFactory().Create(fila, letra, esPrioridad);
		}

		[Fact]
		public void CrearAsientoHandler_HandlerCorrectly() {
			asientoFactory.Setup(factory => factory.Create(fila, letra, esPrioridad)).Returns(Asiento_Test);

			var objHandler = new CrearAsientoHandler(
				asientoRepository.Object,
				logger.Object,
				asientoFactory.Object,
				unitOfWork.Object);
			var objRequest = new CrearAsientoComand(fila, letra, esPrioridad);

			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			Assert.IsType<Guid>(result.Result);
		}

		[Fact]
		public void CrearAsientoHandler_HandlerFail() {
			// Failling by returning null values
			var objHandler = new CrearAsientoHandler(
				asientoRepository.Object,
				logger.Object,
				asientoFactory.Object,
				unitOfWork.Object);

			var objRequest = new CrearAsientoComand(fila, letra, esPrioridad);

			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);

			logger.Verify(mock => mock.Log(
				It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
				It.Is<EventId>(eventId => eventId.Id == 0),
				It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Error al crear Asiento"),
				It.IsAny<Exception>(),
				It.IsAny<Func<It.IsAnyType, Exception, string>>())
			, Times.Once);
		}

	}
}
