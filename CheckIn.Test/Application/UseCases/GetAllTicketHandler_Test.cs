using CheckIn.Application.UseCases.Ticket;
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
	public class GetAllTicketHandler_Test {

		private readonly Mock<ITicketRepository> asientoRepository;
		private readonly Mock<ILogger<GetAllTicketHandler>> logger;

		public GetAllTicketHandler_Test() {
			asientoRepository = new Mock<ITicketRepository>();
			logger = new Mock<ILogger<GetAllTicketHandler>>();
		}

		[Fact]
		public void Handler_Correctly() {
			var tcs = new CancellationTokenSource(1000);
			var handler = new GetAllTicketHandler(asientoRepository.Object, logger.Object);
			var result = handler.Handle(new GetAllTicketQuery(), tcs.Token);

			Assert.NotNull(result.Result);
		}
	}
}
