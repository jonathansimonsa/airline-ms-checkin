using CheckIn.Domain.Factories.CheckIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Domain.Factory {
	public class CheckInFactory_Test {
		[Fact]
		public void Create_Correctly() {
			string nro_test = "QAZ";
			int prioridad_test = 1;
			string letraAsiento_test = "P";
			int nroAsiento_test = 7;
			Guid reservaId_test = Guid.NewGuid();
			Guid vueloId_test = Guid.NewGuid();

			var factory = new CheckInFactory();
			var obj = factory.Create(nro_test, prioridad_test, letraAsiento_test, nroAsiento_test, reservaId_test, vueloId_test);

			Assert.NotNull(obj);
			Assert.Equal(nro_test, obj.NroCheckIn);
			Assert.Equal(prioridad_test, obj.EsAltaPrioridad);
			Assert.Equal(letraAsiento_test, obj.LetraAsiento);
			Assert.Equal(nroAsiento_test, obj.NroAsiento);
			Assert.Equal(reservaId_test, obj.ReservaId);
		}
	}
}
