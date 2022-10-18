using CheckIn.Infraestructure.EF.ReadModel.Reserva;
using CheckIn.Infraestructure.EF.ReadModel.Vuelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Infraestructure.ReadModel {
	public class VueloReadModel_Test {

		[Fact]
		public void CheckValidProps() {

			var id_Test = Guid.NewGuid();
			var nro_Test = 11;
			var origen_Test = "SC";
			var destino_Test = "LP";

			var obj = new VueloReadModel();

			Assert.Equal(Guid.Empty, obj.Id);
			Assert.Equal(0, obj.NroVuelo);
			Assert.Null(obj.Origen);
			Assert.Null(obj.Destino);

			obj.Id = id_Test;
			obj.NroVuelo = nro_Test;
			obj.Origen = origen_Test;
			obj.Destino = destino_Test;

			Assert.Equal(id_Test, obj.Id);
			Assert.Equal(nro_Test, obj.NroVuelo);
			Assert.Equal(origen_Test, obj.Origen);
			Assert.Equal(destino_Test, obj.Destino);
		}

	}
}
