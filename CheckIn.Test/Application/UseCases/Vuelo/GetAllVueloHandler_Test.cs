using CheckIn.Application.UseCases.Vuelo;
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
	public class GetAllVueloHandler_Test {

		private readonly Mock<IVueloRepository> vueloRepository;
		private readonly Mock<ILogger<GetAllVueloHandler>> logger;

		public GetAllVueloHandler_Test() {
			vueloRepository = new Mock<IVueloRepository>();
			logger = new Mock<ILogger<GetAllVueloHandler>>();
		}

		[Fact]
		public void Handler_Correctly() {
			var tcs = new CancellationTokenSource(1000);
			var handler = new GetAllVueloHandler(vueloRepository.Object, logger.Object);
			var result = handler.Handle(new GetAllVueloQuery(), tcs.Token);

			Assert.NotNull(result.Result);
		}
	}
}
