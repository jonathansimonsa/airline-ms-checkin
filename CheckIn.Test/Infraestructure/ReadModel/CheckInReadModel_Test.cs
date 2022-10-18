using CheckIn.Infraestructure.EF.ReadModel.CheckIn;
using CheckIn.Infraestructure.EF.ReadModel.Reserva;
using CheckIn.Infraestructure.EF.ReadModel.Vuelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Infraestructure.ReadModel {
	public class CheckInReadModel_Test {

		[Fact]
		public void CheckValidProps() {

			var idTest = Guid.NewGuid();
			var nroCheckInTest = "QAZ";
			var horaTest = DateTime.Now;
			var prioridadTest = 1;
			var letraAsientoTest = "P";
			var nroAsientoTest = 7;
			var detalleTest = getDetalleCheckIn();
			var reservaIdTest = new ReservaReadModel();
			var vueloIdTest = new VueloReadModel();

			var obj = new CheckInReadModel();

			Assert.Equal(Guid.Empty, obj.Id);
			Assert.Null(obj.NroCheckIn);
			Assert.Equal(new DateTime(1, 1, 1, 0, 0, 0, 0), obj.Hora);
			Assert.Equal(0, obj.EsAltaPrioridad);
			Assert.Null(obj.LetraAsiento);
			Assert.Equal(0, obj.NroAsiento);
			Assert.Null(obj.Reserva);
			Assert.Empty(obj.DetalleEquipaje);

			obj.Id = idTest;
			obj.NroCheckIn = nroCheckInTest;
			obj.Hora = horaTest;
			obj.EsAltaPrioridad = prioridadTest;
			obj.LetraAsiento = letraAsientoTest;
			obj.NroAsiento = nroAsientoTest;
			obj.DetalleEquipaje = detalleTest;
			obj.Reserva = reservaIdTest;
			obj.Vuelo = vueloIdTest;

			Assert.Equal(idTest, obj.Id);
			Assert.Equal(nroCheckInTest, obj.NroCheckIn);
			Assert.Equal(horaTest, obj.Hora);
			Assert.Equal(prioridadTest, obj.EsAltaPrioridad);
			Assert.Equal(letraAsientoTest, obj.LetraAsiento);
			Assert.Equal(nroAsientoTest, obj.NroAsiento);
			Assert.Equal(reservaIdTest, obj.Reserva);
			Assert.Equal(detalleTest.Count, obj.DetalleEquipaje.Count);
		}

		private List<EquipajeReadModel> getDetalleCheckIn() {
			return new List<EquipajeReadModel>() {
				new()
				{
					Id = Guid.NewGuid(),
					Descripcion = "Maleta #1",
					Peso = 34,
					EsFragil=0
				},
				new()
				{
					Id = Guid.NewGuid(),
					Descripcion = "Maleta #2",
					Peso = 14,
					EsFragil=0
				},
				new()
				{
					Id = Guid.NewGuid(),
					Descripcion = "Maleta #3",
					Peso = 52,
					EsFragil=0
				}
			};
		}
	}
}
