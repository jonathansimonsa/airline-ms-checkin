using CheckIn.Application.UseCases.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Application.UseCases {
	public class CrearTicketComand_Test {

		[Fact]
		public void CrearTicketCommand_DataValid() {
			var horaReserva = DateTime.Now;
			var vueloId = Guid.NewGuid();
			var command = new CreateTicketCommand(horaReserva, vueloId);

			Assert.Equal(horaReserva, command.HoraReserva);
			Assert.Equal(vueloId, command.VueloId);
		}

		[Fact]
		public void Constructor_isPridate() {
			var command = (CreateTicketCommand)Activator.CreateInstance(typeof(CreateTicketCommand), true);

			Assert.Equal(new DateTime(1, 1, 1, 0, 0, 0, 0), command.HoraReserva);
			Assert.Equal(Guid.Empty, command.VueloId);
		}
	}
}
