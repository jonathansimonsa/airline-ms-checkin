using CheckIn.Application.UseCases.Reserva;
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
	public class GetAllReservaHandler_Test {

		private readonly Mock<IReservaRepository> asientoRepository;
		private readonly Mock<ILogger<GetAllReservaHandler>> logger;

		public GetAllReservaHandler_Test() {
			asientoRepository = new Mock<IReservaRepository>();
			logger = new Mock<ILogger<GetAllReservaHandler>>();
		}

		[Fact]
		public void Handler_Correctly() {
			var tcs = new CancellationTokenSource(1000);
			var handler = new GetAllReservaHandler(asientoRepository.Object, logger.Object);
			var result = handler.Handle(new GetAllReservaQuery(), tcs.Token);

			Assert.NotNull(result.Result);
		}
	}
}
