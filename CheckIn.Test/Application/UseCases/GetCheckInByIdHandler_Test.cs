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

namespace CheckIn.Test.Application.UseCases
{
    public class GetCheckInByIdHandler_Test
    {

        private readonly Mock<ICheckInRepository> checkInRepository;
        private readonly Mock<ILogger<GetCheckInByIdQuery>> logger;

        public GetCheckInByIdHandler_Test()
        {
            checkInRepository = new Mock<ICheckInRepository>();
            logger = new Mock<ILogger<GetCheckInByIdQuery>>();
        }

        [Fact]
        public void Handler_Correctly()
        {
            var tcs = new CancellationTokenSource(1000);
            var handler = new GetCheckInByIdHandler(checkInRepository.Object, logger.Object);
            var result = handler.Handle(new GetCheckInByIdQuery(Guid.NewGuid()), tcs.Token);

            Assert.True(result.IsCompletedSuccessfully);
        }
    }
}
