using CheckIn.Domain.Model.Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Domain.Model {
	public class Reserva_Test {
		[Fact]
		public void Ticket_CheckPropertiesValid() {
			var obj = new Reserva();

			Assert.Equal(Guid.Empty, obj.Id);
			Assert.Equal(1, obj.Hora.Year);
		}
	}
}
