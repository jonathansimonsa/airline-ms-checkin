using CheckIn.Domain.Factories.Vuelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Domain.Factory {
	public class VueloFactory_Test {
		[Fact]
		public void Create_Correctly() {
			int nro = 7;
			string origen = "SC";
			string destino = "LP";

			var factory = new VueloFactory();
			var obj = factory.Create(Guid.NewGuid(), nro, origen, destino);

			Assert.NotNull(obj);
			Assert.Equal(nro, obj.NroVuelo);
			Assert.Equal(origen, obj.Origen);
			Assert.Equal(destino, obj.Destino);
		}
	}
}
