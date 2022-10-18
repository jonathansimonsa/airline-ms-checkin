using CheckIn.Application.UseCases.Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Application.UseCases {
	public class CreateReservaCommand_Test {

		[Fact]
		public void DataValid() {
			var id = Guid.NewGuid();
			var hora = DateTime.Now;
			var vueloId = Guid.NewGuid();

			var command = new CreateReservaCommand(id, hora, vueloId);

			Assert.Equal(id, command.Id);
			Assert.Equal(hora, command.Hora);
			Assert.Equal(vueloId, command.VueloId);
		}

		[Fact]
		public void Constructor_isPridate() {
			var command = (CreateReservaCommand)Activator.CreateInstance(typeof(CreateReservaCommand), true);

			Assert.Equal(Guid.Empty, command.Id);
			Assert.Equal(new DateTime(1, 1, 1, 0, 0, 0, 0), command.Hora);
			Assert.Equal(Guid.Empty, command.VueloId);
		}
	}
}
