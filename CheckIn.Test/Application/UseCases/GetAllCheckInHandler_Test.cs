using CheckIn.Application.UseCases.CheckIn;
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
	public class GetAllCheckInHandler_Test {

		private readonly Mock<ICheckInRepository> checkInRepository;
		private readonly Mock<ILogger<GetAllCheckInHandler>> logger;

		public GetAllCheckInHandler_Test() {
			checkInRepository = new Mock<ICheckInRepository>();
			logger = new Mock<ILogger<GetAllCheckInHandler>>();
		}

		[Fact]
		public void Handler_Correctly() {
			var tcs = new CancellationTokenSource(1000);
			var handler = new GetAllCheckInHandler(checkInRepository.Object, logger.Object);
			var result = handler.Handle(new GetAllCheckInQuery(), tcs.Token);

			Assert.NotNull(result.Result);
		}
	}
}
