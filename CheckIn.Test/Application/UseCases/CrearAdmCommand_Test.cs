using CheckIn.Application.UseCases.Adm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Application.UseCases {
	public class CrearAdmCommand_Test {
		[Fact]
		public void CrearAdmCommand_DataValid() {
			var ci = "8648023";
			var nombres = "Juancho";
			var apellidos = "Rodriguez";
			var cargo = "Vendedor";
			var command = new CreateAdmCommand(ci, nombres, apellidos, cargo);

			Assert.Equal(ci, command.Ci);
			Assert.Equal(nombres, command.Nombres);
			Assert.Equal(apellidos, command.Apellidos);
			Assert.Equal(cargo, command.Cargo);
		}

		[Fact]
		public void Constructor_isPridate() {
			var command = (CreateAdmCommand)Activator.CreateInstance(typeof(CreateAdmCommand), true);

			Assert.Null(command.Ci);
			Assert.Null(command.Nombres);
			Assert.Null(command.Apellidos);
			Assert.Null(command.Cargo);
		}

	}
}
