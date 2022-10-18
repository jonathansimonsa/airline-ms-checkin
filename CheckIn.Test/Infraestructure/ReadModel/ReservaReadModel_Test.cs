using CheckIn.Infraestructure.EF.ReadModel.Reserva;
using CheckIn.Infraestructure.EF.ReadModel.Vuelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Infraestructure.ReadModel {
	public class ReservaReadModel_Test {
		[Fact]
		public void CheckValidProps() {

			var id_Test = Guid.NewGuid();
			var hora_Test = DateTime.Now;
			var nroReserva_Test = 11;
			var vueloId_Test = new VueloReadModel();

			var obj = new ReservaReadModel();

			Assert.Equal(Guid.Empty, obj.Id);
			Assert.Equal(new DateTime(1, 1, 1, 0, 0, 0, 0), obj.Hora);
			Assert.Equal(0, obj.NroReserva);
			Assert.Null(obj.Vuelo);

			obj.Id = id_Test;
			obj.Hora = hora_Test;
			obj.NroReserva = nroReserva_Test;
			obj.Vuelo = vueloId_Test;

			Assert.Equal(id_Test, obj.Id);
			Assert.Equal(hora_Test, obj.Hora);
			Assert.Equal(nroReserva_Test, obj.NroReserva);
			Assert.Equal(vueloId_Test, obj.Vuelo);
		}
	}
}
