using CheckIn.Application.UseCases.Adm;
using CheckIn.Domain.Factories.Adm;
using CheckIn.Domain.Model.Adm;
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
	public class CrearAdmHandler_Test {
		private readonly Mock<IAdministrativoRepository> admRepository;
		private readonly Mock<ILogger<CrearAdmHandler>> logger;
		private readonly Mock<IAdministrativoFactory> admFactory;
		private readonly Mock<IUnitOfWork> unitOfWork;
		private string ci = "1234567";
		private string nombres = "Luis";
		private string apellidos = "Lopez";
		private string cargo = "Piloto";
		private Administrativo Adm_Test;

		public CrearAdmHandler_Test() {
			admRepository = new Mock<IAdministrativoRepository>();
			logger = new Mock<ILogger<CrearAdmHandler>>();
			admFactory = new Mock<IAdministrativoFactory>();
			unitOfWork = new Mock<IUnitOfWork>();
			Adm_Test = new AdministrativoFactory().Create(ci, nombres, apellidos, cargo);
		}

		[Fact]
		public void CrearAdmHandler_HandlerCorrectly() {
			admFactory.Setup(factory => factory.Create(ci, nombres, apellidos, cargo)).Returns(Adm_Test);

			var objHandler = new CrearAdmHandler(
				admRepository.Object,
				logger.Object,
				admFactory.Object,
				unitOfWork.Object);
			var objRequest = new CrearAdmCommand(ci, nombres, apellidos, cargo);

			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			Assert.IsType<Guid>(result.Result);
		}

		[Fact]
		public void CrearAdmHandler_HandlerFail() {
			// Failling by returning null values
			var objHandler = new CrearAdmHandler(
				admRepository.Object,
				logger.Object,
				admFactory.Object,
				unitOfWork.Object);

			var objRequest = new CrearAdmCommand(ci, nombres, apellidos, cargo);

			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);

			logger.Verify(mock => mock.Log(
				It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
				It.Is<EventId>(eventId => eventId.Id == 0),
				It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Error al crear Administrativo"),
				It.IsAny<Exception>(),
				It.IsAny<Func<It.IsAnyType, Exception, string>>())
			, Times.Once);
		}

	}
}
