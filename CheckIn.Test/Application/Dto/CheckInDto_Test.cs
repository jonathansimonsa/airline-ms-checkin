using CheckIn.Application.Dto.CheckIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Application.Dto {
	public class CheckInDto_Test {
		[Fact]
		public void CheckInDto_CheckPropertiesValid() {
			var idTest = Guid.NewGuid();
			var nroCheckInTest = "QAZ";
			var horaTest = DateTime.Now;
			var prioridadTest = 0;
			var letraAsiento = "P";
			var NroAsiento = 7;
			var detalleTest = getDetalleCheckIn();
			var ticketIdTest = Guid.NewGuid();
			var asientoIdTest = Guid.NewGuid();
			var admIdTest = Guid.NewGuid();

			var objCheckIn = new CheckInDto();

			Assert.Equal(Guid.Empty, objCheckIn.Id);
			Assert.Null(objCheckIn.NroCheckIn);
			Assert.Equal(new DateTime(1, 1, 1, 0, 0, 0, 0), objCheckIn.HoraCheckIn);
			Assert.Equal(0, objCheckIn.EsAltaPrioridad);
			Assert.Null(objCheckIn.LetraAsiento);
			Assert.Equal(0, objCheckIn.NroAsiento);
			Assert.Equal(Guid.Empty, objCheckIn.TicketId);
			Assert.Equal(Guid.Empty, objCheckIn.AdministrativoId);
			Assert.Empty(objCheckIn.DetalleEquipaje);

			objCheckIn.Id = idTest;
			objCheckIn.NroCheckIn = nroCheckInTest;
			objCheckIn.HoraCheckIn = horaTest;
			objCheckIn.EsAltaPrioridad = prioridadTest;
			objCheckIn.LetraAsiento = letraAsiento;
			objCheckIn.NroAsiento = NroAsiento;
			objCheckIn.DetalleEquipaje = detalleTest;
			objCheckIn.TicketId = ticketIdTest;
			objCheckIn.AdministrativoId = admIdTest;

			Assert.Equal(idTest, objCheckIn.Id);
			Assert.Equal(nroCheckInTest, objCheckIn.NroCheckIn);
			Assert.Equal(horaTest, objCheckIn.HoraCheckIn);
			Assert.Equal(prioridadTest, objCheckIn.EsAltaPrioridad);
			Assert.Equal(letraAsiento, objCheckIn.LetraAsiento);
			Assert.Equal(NroAsiento, objCheckIn.NroAsiento);
			Assert.Equal(ticketIdTest, objCheckIn.TicketId);
			Assert.Equal(admIdTest, objCheckIn.AdministrativoId);
			Assert.Equal(detalleTest.Count, objCheckIn.DetalleEquipaje.Count);
		}

		private List<EquipajeDto> getDetalleCheckIn() {
			return new List<EquipajeDto>() {
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
