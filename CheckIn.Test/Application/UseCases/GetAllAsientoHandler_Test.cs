using CheckIn.Application.UseCases.Avion;
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

namespace CheckIn.Test.Application.UseCases
{
   public class GetAllAsientoHandler_Test
    {

        private readonly Mock<IAsientoRepository> asientoRepository;
        private readonly Mock<ILogger<GetAllAsientoQuery>> logger;

        public GetAllAsientoHandler_Test()
        {
            asientoRepository = new Mock<IAsientoRepository>();
            logger = new Mock<ILogger<GetAllAsientoQuery>>();
        }

        [Fact]
        public void Handler_Correctly()
        {
            var tcs = new CancellationTokenSource(1000);
            var handler = new GetAllAsientoHandler(asientoRepository.Object, logger.Object);
            var result = handler.Handle(new GetAllAsientoQuery(), tcs.Token);

            Assert.NotNull(result.Result);
        }
    }
}
