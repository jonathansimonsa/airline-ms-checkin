using CheckIn.Application.Services;
using CheckIn.Application.UseCases.CheckIn;
using CheckIn.Domain.Factories.CheckIn;
using CheckIn.Domain.Model.Reserva;
using CheckIn.Domain.Model.Vuelo;
using CheckIn.Domain.Repositories;
using CheckIn.Infraestructure.EF.Repository;
using CheckIn.Test.Domain.Model;
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
	public class DeleteCheckInHandler_Test {
		private readonly Mock<ICheckInRepository> checkInRepository;
		private readonly Mock<ILogger<DeleteCheckInHandler>> logger;
		private readonly Mock<ICheckInFactory> checkInFactory;
		private readonly Mock<IUnitOfWork> unitOfWork;

		private Guid id = Guid.NewGuid();


		public DeleteCheckInHandler_Test() {
			checkInRepository = new Mock<ICheckInRepository>();
			logger = new Mock<ILogger<DeleteCheckInHandler>>();
			checkInFactory = new Mock<ICheckInFactory>();
			unitOfWork = new Mock<IUnitOfWork>();
		}

		[Fact]
		public void HandlerCorrectly() {

			var objHandler = new DeleteCheckInHandler(
				checkInRepository.Object,
				logger.Object,
				checkInFactory.Object,
				unitOfWork.Object);
			var objRequest = new DeleteCheckInCommand(id);

			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			Assert.IsType<Guid>(result.Result);
		}
	}
}
