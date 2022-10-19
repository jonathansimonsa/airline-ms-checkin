using CheckIn.Application.UseCases.Reserva;
using CheckIn.Application.UseCases.ReservaLibre;
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

namespace CheckIn.Test.Application.UseCases.ReservaLibre {
	public class GetAllReservaLibreHandler_Test {

		private readonly Mock<IReservaRepository> reservaRepository;
		private readonly Mock<ICheckInRepository> checkInRepository;
		private readonly Mock<ILogger<GetAllReservaLibreHandler>> logger;

		public GetAllReservaLibreHandler_Test() {
			reservaRepository = new Mock<IReservaRepository>();
			checkInRepository = new Mock<ICheckInRepository>();
			logger = new Mock<ILogger<GetAllReservaLibreHandler>>();
		}

		[Fact]
		public void Handler_Correctly() {
			var tcs = new CancellationTokenSource(1000);
			var handler = new GetAllReservaLibreHandler(reservaRepository.Object, checkInRepository.Object, logger.Object);
			var result = handler.Handle(new GetAllReservaLibreQuery(), tcs.Token);

			Assert.NotNull(result.Result);
		}
	}
}
