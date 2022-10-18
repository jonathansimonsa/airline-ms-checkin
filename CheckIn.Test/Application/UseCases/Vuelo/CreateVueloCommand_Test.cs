using CheckIn.Application.UseCases.Vuelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Application.UseCases {
	public class CreateVueloCommand_Test {

		[Fact]
		public void DataValid() {
			var id = Guid.NewGuid();
			var origen = "SC";
			var destino = "LP";

			var command = new CreateVueloCommand(id, origen, destino);

			Assert.Equal(id, command.Id);
			Assert.Equal(origen, command.Origen);
			Assert.Equal(destino, command.Destino);
		}

		[Fact]
		public void Constructor_isPridate() {
			var command = (CreateVueloCommand)Activator.CreateInstance(typeof(CreateVueloCommand), true);

			Assert.Equal(Guid.Empty, command.Id);
			Assert.Null(command.Origen);
			Assert.Null(command.Destino);
		}
	}
}
