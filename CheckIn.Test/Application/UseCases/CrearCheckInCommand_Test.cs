using CheckIn.Application.Dto.CheckIn;
using CheckIn.Application.UseCases.CheckIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Application.UseCases {
	public class CrearCheckInCommand_Test {
		[Fact]
		public void CrearCheckInCommand_DataValid() {
			var altaPrioridad = 1;
			var ticketId = Guid.NewGuid();
			var asientoId = Guid.NewGuid();
			var administrativoId = Guid.NewGuid();
			var detalle = new List<EquipajeDto>() {
				new EquipajeDto() { Id = Guid.NewGuid(), Descripcion = "maleta #1", Peso = 7, EsFragil = 1 },
				new EquipajeDto() { Id = Guid.NewGuid(), Descripcion = "maleta #2", Peso = 6, EsFragil = 1 }};
			var command = new CreateCheckInCommand(altaPrioridad, ticketId, administrativoId, detalle);

			Assert.Equal(altaPrioridad, command.EsAltaPrioridad);
			Assert.Equal(ticketId, command.TicketId);
			Assert.Equal(administrativoId, command.AdministrativoId);
			Assert.Equal(detalle.Count(), command.Detalle.Count());
		}

		[Fact]
		public void Constructor_isPridate() {
			var command = (CreateCheckInCommand)Activator.CreateInstance(typeof(CreateCheckInCommand), true);

			Assert.Equal(0, command.EsAltaPrioridad);
			Assert.Equal(Guid.Empty, command.TicketId);
			Assert.Equal(Guid.Empty, command.AdministrativoId);
			Assert.Null(command.Detalle);
		}
	}
}
