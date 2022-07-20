using CheckIn.Application.Dto.CheckIn;
using CheckIn.Application.Services;
using CheckIn.Application.UseCases.CheckIn;
using CheckIn.Domain.Factories.CheckIn;
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
	public class CrearCheckInHandler_Test {
		private readonly Mock<ICheckInRepository> checkInRepository;
		private readonly Mock<ILogger<CrearCheckInHandler>> logger;
		private readonly Mock<ICheckInService> checkInService;
		private readonly Mock<ICheckInFactory> checkInFactory;
		private readonly Mock<IUnitOfWork> unitOfWork;
		private string nroCheckIn = "QAZ";
		private int esAltaPrioridad = 1;
		private Guid ticketId = Guid.NewGuid();
		private Guid asientoId = Guid.NewGuid();
		private Guid checkInId = Guid.NewGuid();
		private List<EquipajeDto> detalle = new List<EquipajeDto>() {
				new EquipajeDto() { Id = Guid.NewGuid(), Descripcion = "maleta #1", Peso = 7, EsFragil = 1 },
				new EquipajeDto() { Id = Guid.NewGuid(), Descripcion = "maleta #2", Peso = 6, EsFragil = 1 }};
		private CheckIn.Domain.Model.CheckIn.CheckIn CheckIn_Test;

		public CrearCheckInHandler_Test() {
			checkInRepository = new Mock<ICheckInRepository>();
			logger = new Mock<ILogger<CrearCheckInHandler>>();
			checkInService = new Mock<ICheckInService>();
			checkInFactory = new Mock<ICheckInFactory>();
			unitOfWork = new Mock<IUnitOfWork>();
			CheckIn_Test = new CheckInFactory().Create(nroCheckIn, esAltaPrioridad, ticketId, asientoId, checkInId);
		}

		[Fact]
		public void CrearCheckInHandler_HandlerCorrectly() {
			checkInService.Setup(checkInService => checkInService.GenerarNroCheckInAsync()).Returns(Task.FromResult(nroCheckIn));
			checkInFactory.Setup(factory => factory.Create(nroCheckIn, esAltaPrioridad, ticketId, asientoId, checkInId)).Returns(CheckIn_Test);

			var objHandler = new CrearCheckInHandler(
				checkInRepository.Object,
				logger.Object,
				checkInService.Object,
				checkInFactory.Object,
				unitOfWork.Object);
			var objRequest = new CrearCheckInCommand(esAltaPrioridad, ticketId, asientoId, checkInId, detalle);

			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			Assert.IsType<Guid>(result.Result);
		}

		[Fact]
		public void CrearCheckInHandler_HandlerFail() {
			// Failling by returning null values
			var objHandler = new CrearCheckInHandler(
				checkInRepository.Object,
				logger.Object,
				checkInService.Object,
				checkInFactory.Object,
				unitOfWork.Object);

			var objRequest = new CrearCheckInCommand(esAltaPrioridad, ticketId, asientoId, checkInId, detalle);

			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);

			logger.Verify(mock => mock.Log(
				It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
				It.Is<EventId>(eventId => eventId.Id == 0),
				It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Error al crear CheckIn"),
				It.IsAny<Exception>(),
				It.IsAny<Func<It.IsAnyType, Exception, string>>())
			, Times.Once);
		}
	}
}
