using CheckIn.Domain.Factories.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Domain.Factory {
	public class TicketFactory_Test {
		[Fact]
		public void Create_Correctly() {
			int nroTicket = 7;
			DateTime hora_test = DateTime.Now;
			Guid vueloId_test = Guid.NewGuid();

			var factory = new TicketFactory();
			var obj = factory.Create(nroTicket, hora_test, vueloId_test);

			Assert.NotNull(obj);
			Assert.Equal(nroTicket, obj.NroTicket);
			Assert.Equal(hora_test, obj.HoraReserva);
			Assert.Equal(vueloId_test, obj.VueloId);
		}
	}
}
