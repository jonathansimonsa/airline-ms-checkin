using CheckIn.Application.Dto.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Application.Dto
{
    public class TicketDto_Test
    {
        [Fact]
        public void TicketDto_CheckPropertiesValid()
        {
            var id_Test = Guid.NewGuid();
            var hora_Test = DateTime.Now;

            var obj = new TicketDto();

            Assert.Equal(Guid.Empty, obj.Id);
            Assert.Equal(new DateTime(1, 1, 1, 0, 0, 0, 0), obj.HoraReserva);

            obj.Id = id_Test;
            obj.HoraReserva = hora_Test;

            Assert.Equal(id_Test, obj.Id);
            Assert.Equal(hora_Test, obj.HoraReserva);
        }
    }
}
