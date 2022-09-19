using CheckIn.Domain.Factories.Reserva;
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
			int nro = 7;
			DateTime hora_test = DateTime.Now;
			Guid vueloId_test = Guid.NewGuid();

			var factory = new ReservaFactory();
			var obj = factory.Create(Guid.NewGuid(), nro, hora_test, vueloId_test);

			Assert.NotNull(obj);
			Assert.Equal(nro, obj.NroReserva);
			Assert.Equal(hora_test, obj.Hora);
			Assert.Equal(vueloId_test, obj.VueloId);
		}
	}
}
