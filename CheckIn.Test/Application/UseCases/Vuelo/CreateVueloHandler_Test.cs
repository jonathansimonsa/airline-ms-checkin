using CheckIn.Application.UseCases.Reserva;
using CheckIn.Application.UseCases.Vuelo;
using CheckIn.Domain.Factories.Reserva;
using CheckIn.Domain.Factories.Vuelo;
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
	public class CreateVueloHandler_Test {

		private readonly Mock<IVueloRepository> vueloRepository;
		private readonly Mock<ILogger<CreateVueloHandler>> logger;
		private readonly Mock<IVueloFactory> vueloFactory;
		private readonly Mock<IUnitOfWork> unitOfWork;
		private Guid id = Guid.NewGuid();
		private int nroVuelo = 11;
		private string origen = "SC";
		private string destino = "LP";
		private CheckIn.Domain.Model.Vuelo.Vuelo Vuelo_Test;

		public CreateVueloHandler_Test() {
			vueloRepository = new Mock<IVueloRepository>();
			logger = new Mock<ILogger<CreateVueloHandler>>();
			vueloFactory = new Mock<IVueloFactory>();
			unitOfWork = new Mock<IUnitOfWork>();
			Vuelo_Test = new VueloFactory().Create(id, nroVuelo, origen, destino);
		}

		[Fact]
		public void CrearVueloHandler_HandlerCorrectly() {
			vueloFactory.Setup(factory => factory.Create(id, nroVuelo, origen, destino)).Returns(Vuelo_Test);

			var objHandler = new CreateVueloHandler(
				vueloRepository.Object,
				logger.Object,
				vueloFactory.Object,
				unitOfWork.Object);
			var objRequest = new CreateVueloCommand(id, origen, destino);

			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			Assert.IsType<Guid>(result.Result);
		}

		[Fact]
		public void CrearVueloHandler_HandlerFail() {
			// Failling by returning null values
			var objHandler = new CreateVueloHandler(
				vueloRepository.Object,
				logger.Object,
				vueloFactory.Object,
				unitOfWork.Object);

			var objRequest = new CreateVueloCommand(id, origen, destino);

			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);

			logger.Verify(mock => mock.Log(
				It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
				It.Is<EventId>(eventId => eventId.Id == 0),
				It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Error al crear Vuelo"),
				It.IsAny<Exception>(),
				It.IsAny<Func<It.IsAnyType, Exception, string>>())
			, Times.Once);
		}
	}
}
