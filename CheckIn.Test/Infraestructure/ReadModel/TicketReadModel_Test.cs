using CheckIn.Infraestructure.EF.ReadModel.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Infraestructure.ReadModel
{
    public class TicketReadModel_Test
    {
        [Fact]
        public void CheckValidProps()
        {

            var id_Test = Guid.NewGuid();
            var hora_Test = DateTime.Now;

            var obj = new TicketReadModel();

            Assert.Equal(Guid.Empty, obj.Id);
            Assert.Equal(new DateTime(1, 1, 1, 0, 0, 0, 0), obj.HoraReserva);

            obj.Id = id_Test;
            obj.HoraReserva = hora_Test;

            Assert.Equal(id_Test, obj.Id);
            Assert.Equal(hora_Test, obj.HoraReserva);
        }
    }
}
