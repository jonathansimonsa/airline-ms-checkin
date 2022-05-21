using Castle.Core.Logging;
using CheckIn.Application.UseCases.Adm;
using CheckIn.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Application.UseCases.Command
{
    public class GetAllAdmHandler_Test
    {
        private readonly Mock<IAdministrativoRepository> admRepository;
        private readonly Mock<ILogger<GetAllAdmQuery>> logger;

        public GetAllAdmHandler_Test()
        {
            admRepository = new Mock<IAdministrativoRepository>();
        }

        [Fact]
        public void Handler_Correctly()
        {
           // var handler = GetAllAdmHandler(admRepository.Object, logger.Object);
        }
    }
}
