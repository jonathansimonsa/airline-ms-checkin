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
using Vuelo.Application.UseCases.Vuelo;
using Xunit;

namespace CheckIn.Test.Application.UseCases {
	public class GetVueloByIdHandler_Test {


		private readonly Mock<IVueloRepository> vueloRepository;
		private readonly Mock<ILogger<GetVueloByIdHandler>> logger;

		public GetVueloByIdHandler_Test() {
			vueloRepository = new Mock<IVueloRepository>();
			logger = new Mock<ILogger<GetVueloByIdHandler>>();
		}

		[Fact]
		public void Handler_Correctly() {
			var tcs = new CancellationTokenSource(1000);
			var handler = new GetVueloByIdHandler(vueloRepository.Object, logger.Object);
			var result = handler.Handle(new GetVueloByIdQuery(Guid.NewGuid()), tcs.Token);

			Assert.True(result.IsCompletedSuccessfully);
		}

	}
}
