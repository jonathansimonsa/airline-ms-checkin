using CheckIn.Application.UseCases.Reserva;
using CheckIn.Application.UseCases.Vuelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Application.UseCases {
	public class DeleteVueloCommand_Test {
		[Fact]
		public void DataValid() {
			var id = Guid.NewGuid();
			var command = new DeleteVueloCommand(id);

			Assert.Equal(id, command.Id);
		}

		[Fact]
		public void Constructor_isPridate() {
			var command = (DeleteVueloCommand)Activator.CreateInstance(typeof(DeleteVueloCommand), true);


			Assert.Equal(Guid.Empty, command.Id);
		}
	}
}
