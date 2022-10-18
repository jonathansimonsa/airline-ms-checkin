using ShareKernel.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.ShareKernel.IntegrationEvents {
	public class ReservaCreado_Test {

		[Fact]
		public void CheckValue() {
			var obj = new ReservaCreado();

			Assert.Null(obj.reservaId);
			Assert.Null(obj.hora);
			Assert.Null(obj.vueloId);
			Assert.Null(obj.origen);
			Assert.Null(obj.destino);
			Assert.Null(obj.pagoId);

			var creado_en = obj.OcurredOn;
		}

	}
}
