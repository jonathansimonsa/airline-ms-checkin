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
	public class DeleteReservaHandler_Test {
		private readonly Mock<IReservaRepository> reservaRepository;
		private readonly Mock<ILogger<DeleteReservaHandler>> logger;
		private readonly Mock<IReservaFactory> reservaFactory;
		private readonly Mock<IUnitOfWork> unitOfWork;

		private Guid id = Guid.NewGuid();


		public DeleteReservaHandler_Test() {
			reservaRepository = new Mock<IReservaRepository>();
			logger = new Mock<ILogger<DeleteReservaHandler>>();
			reservaFactory = new Mock<IReservaFactory>();
			unitOfWork = new Mock<IUnitOfWork>();
		}

		[Fact]
		public void HandlerCorrectly() {

			var objHandler = new DeleteReservaHandler(
				reservaRepository.Object,
				logger.Object,
				reservaFactory.Object,
				unitOfWork.Object);
			var objRequest = new DeleteReservaCommand(id);

			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			Assert.IsType<Guid>(result.Result);
		}
	}
}
