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
	public class DeleteVueloHandler_Test {

		private readonly Mock<IVueloRepository> vueloRepository;
		private readonly Mock<ILogger<DeleteVueloHandler>> logger;
		private readonly Mock<IVueloFactory> vueloFactory;
		private readonly Mock<IUnitOfWork> unitOfWork;

		private Guid id = Guid.NewGuid();


		public DeleteVueloHandler_Test() {
			vueloRepository = new Mock<IVueloRepository>();
			logger = new Mock<ILogger<DeleteVueloHandler>>();
			vueloFactory = new Mock<IVueloFactory>();
			unitOfWork = new Mock<IUnitOfWork>();
		}

		[Fact]
		public void HandlerCorrectly() {

			var objHandler = new DeleteVueloHandler(
				vueloRepository.Object,
				logger.Object,
				vueloFactory.Object,
				unitOfWork.Object);
			var objRequest = new DeleteVueloCommand(id);

			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			Assert.IsType<Guid>(result.Result);
		}
	}
}
