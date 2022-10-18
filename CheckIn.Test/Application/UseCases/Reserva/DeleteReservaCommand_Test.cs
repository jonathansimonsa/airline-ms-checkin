using CheckIn.Application.UseCases.CheckIn;
using CheckIn.Application.UseCases.Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Application.UseCases {
	public class DeleteReservaCommand_Test {
		[Fact]
		public void DataValid() {
			var id = Guid.NewGuid();
			var command = new DeleteReservaCommand(id);

			Assert.Equal(id, command.Id);
		}

		[Fact]
		public void Constructor_isPridate() {
			var command = (DeleteReservaCommand)Activator.CreateInstance(typeof(DeleteReservaCommand), true);


			Assert.Equal(Guid.Empty, command.Id);
		}
	}
}
