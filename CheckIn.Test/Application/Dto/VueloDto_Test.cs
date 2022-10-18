using CheckIn.Application.Dto.Reserva;
using CheckIn.Application.Dto.Vuelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Application.Dto {
	public class VueloDto_Test {
		[Fact]
		public void VueloDto_CheckPropertiesValid() {

			var id_Test = Guid.NewGuid();
			var nroVuelo_Test = 22;
			var origen_Test = "LP";
			var destino_Test = "CS";

			var obj = new VueloDto();

			Assert.Equal(Guid.Empty, obj.Id);
			Assert.Equal(0, obj.NroVuelo);
			Assert.Null(obj.Origen);
			Assert.Null(obj.Destino);

			obj.Id = id_Test;
			obj.NroVuelo = nroVuelo_Test;
			obj.Origen = origen_Test;
			obj.Destino = destino_Test;

			Assert.Equal(id_Test, obj.Id);
			Assert.Equal(nroVuelo_Test, obj.NroVuelo);
			Assert.Equal(origen_Test, obj.Origen);
			Assert.Equal(destino_Test, obj.Destino);
		}
	}
}
