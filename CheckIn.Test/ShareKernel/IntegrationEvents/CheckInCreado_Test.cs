using ShareKernel.IntegrationEvents;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.ShareKernel.IntegrationEvents {
	public class CheckInCreado_Test {


		[Fact]
		public void CheckValue() {
			var valor = "Exelsior";
			var obj = new CheckInCreado();

			Assert.Equal(Guid.Empty, obj.Id);
			Assert.Null(obj.NroCheckIn);
			Assert.Equal(new DateTime(1, 1, 1, 0, 0, 0, 0), obj.Hora);
			Assert.Equal(0, obj.EsAltaPrioridad);
			Assert.Null(obj.LetraAsiento);
			Assert.Equal(0, obj.NroAsiento);
			Assert.Equal(Guid.Empty, obj.ReservaId);
			Assert.Equal(Guid.Empty, obj.VueloId);
		}
	}
}
