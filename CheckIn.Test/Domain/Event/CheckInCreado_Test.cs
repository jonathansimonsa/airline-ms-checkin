using CheckIn.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Domain.Event {
	public class CheckInCreado_Test {
		[Fact]
		public void CheckInCreado_CheckPropertiesValid() {
			var nroCheckIn = "QAZ";
			var horaCheckIn = DateTime.Now;
			var esAltaPrioridad = 1;
			var ticketId = Guid.NewGuid();
			var asientoId = Guid.NewGuid();
			var administrativoId = Guid.NewGuid();

			var obj = new CheckInCreado(nroCheckIn, horaCheckIn, esAltaPrioridad, ticketId, asientoId, administrativoId);

			Assert.Equal(nroCheckIn, obj.NroCheckIn);
			Assert.Equal(horaCheckIn, obj.HoraCheckIn);
			Assert.Equal(esAltaPrioridad, obj.EsAltaPrioridad);
			Assert.Equal(ticketId, obj.TicketId);
			Assert.Equal(asientoId, obj.AsientoId);
			Assert.Equal(administrativoId, obj.AdministrativoId);

			Assert.NotEqual(Guid.Empty, obj.Id);
			Assert.NotEqual(1, obj.OccuredOn.Year);
		}
	}
}
