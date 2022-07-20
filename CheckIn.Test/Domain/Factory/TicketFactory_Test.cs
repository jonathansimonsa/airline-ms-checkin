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
			DateTime hora_test = DateTime.Now;

			var factory = new TicketFactory();
			var obj = factory.Create(hora_test);

			Assert.NotNull(obj);
			Assert.Equal(hora_test, obj.HoraReserva);
		}
	}
}
