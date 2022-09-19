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
			var letraAsiento = "P";
			var nroAsiento = 7;
			var reservaId = Guid.NewGuid();
			var vueloId = Guid.NewGuid();

			var obj = new CheckInCreado(nroCheckIn, horaCheckIn, esAltaPrioridad, letraAsiento, nroAsiento, reservaId, vueloId);

			Assert.Equal(nroCheckIn, obj.NroCheckIn);
			Assert.Equal(horaCheckIn, obj.Hora);
			Assert.Equal(esAltaPrioridad, obj.EsAltaPrioridad);
			Assert.Equal(letraAsiento, obj.LetraAsiento);
			Assert.Equal(nroAsiento, obj.NroAsiento);
			Assert.Equal(reservaId, obj.ReservaId);
			Assert.Equal(vueloId, obj.VueloId);

			Assert.NotEqual(Guid.Empty, obj.Id);
			Assert.NotEqual(1, obj.OccuredOn.Year);
		}
	}
}
