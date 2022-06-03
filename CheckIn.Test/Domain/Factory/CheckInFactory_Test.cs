using CheckIn.Domain.Factories.CheckIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Domain.Factory
{
    public class CheckInFactory_Test
    {
        [Fact]
        public void Create_Correctly()
        {
            string nro_test = "QAZ";
            int prioridad_test = 1;
            Guid ticketId_test = Guid.NewGuid();
            Guid asientoId_test = Guid.NewGuid();
            Guid admId_test = Guid.NewGuid();

            var factory = new CheckInFactory();
            var obj = factory.Create(nro_test, prioridad_test, ticketId_test, asientoId_test, admId_test);

            Assert.NotNull(obj);
            Assert.Equal(nro_test, obj.NroCheckIn);
            Assert.Equal(prioridad_test, obj.EsAltaPrioridad);
            Assert.Equal(ticketId_test, obj.TicketId);
            Assert.Equal(asientoId_test, obj.AsientoId);
            Assert.Equal(admId_test, obj.AdministrativoId);
        }
    }
}
