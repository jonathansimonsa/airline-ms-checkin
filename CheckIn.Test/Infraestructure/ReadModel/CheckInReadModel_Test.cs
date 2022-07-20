using CheckIn.Infraestructure.EF.ReadModel.Adm;
using CheckIn.Infraestructure.EF.ReadModel.Avion;
using CheckIn.Infraestructure.EF.ReadModel.CheckIn;
using CheckIn.Infraestructure.EF.ReadModel.Ticket;
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
			var prioridadTest = true;
			var detalleTest = getDetalleCheckIn();
			var ticketIdTest = new TicketReadModel();
			var asientoIdTest = new AsientoReadModel();
			var admIdTest = new AdministrativoReadModel();

			var obj = new CheckInReadModel();

			Assert.Equal(Guid.Empty, obj.Id);
			Assert.Null(obj.NroCheckIn);
			Assert.Equal(new DateTime(1, 1, 1, 0, 0, 0, 0), obj.HoraCheckIn);
			Assert.False(obj.EsAltaPrioridad);
			Assert.Null(obj.Ticket);
			Assert.Null(obj.Asiento);
			Assert.Null(obj.Administrativo);
			Assert.Empty(obj.DetalleEquipaje);

			obj.Id = idTest;
			obj.NroCheckIn = nroCheckInTest;
			obj.HoraCheckIn = horaTest;
			obj.EsAltaPrioridad = prioridadTest;
			obj.DetalleEquipaje = detalleTest;
			obj.Ticket = ticketIdTest;
			obj.Asiento = asientoIdTest;
			obj.Administrativo = admIdTest;

			Assert.Equal(idTest, obj.Id);
			Assert.Equal(nroCheckInTest, obj.NroCheckIn);
			Assert.Equal(horaTest, obj.HoraCheckIn);
			Assert.Equal(prioridadTest, obj.EsAltaPrioridad);
			Assert.Equal(ticketIdTest, obj.Ticket);
			Assert.Equal(asientoIdTest, obj.Asiento);
			Assert.Equal(admIdTest, obj.Administrativo);
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
