using Castle.Core.Logging;
using CheckIn.Application.UseCases.Adm;
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
    public class GetAllAdmHandler_Test
    {
        private readonly Mock<IAdministrativoRepository> admRepository;
        private readonly Mock<ILogger<GetAllAdmQuery>> logger;

        public GetAllAdmHandler_Test()
        {
            admRepository = new Mock<IAdministrativoRepository>();
            logger = new Mock<ILogger<GetAllAdmQuery>>();
        }

        [Fact]
        public void Handler_Correctly()
        {
            var tcs = new CancellationTokenSource(1000);
            var handler = new GetAllAdmHandler(admRepository.Object, logger.Object);
            var result = handler.Handle(new GetAllAdmQuery(), tcs.Token);

            Assert.NotNull(result.Result);

            if (result.Result.Any())
            {
                Assert.NotEqual(Guid.Empty, result.Result.First().Id);
            }
        }
    }
}
