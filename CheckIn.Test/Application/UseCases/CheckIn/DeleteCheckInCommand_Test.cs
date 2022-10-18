using CheckIn.Application.UseCases.CheckIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Application.UseCases {
	public class DeleteCheckInCommand_Test {

		[Fact]
		public void DataValid() {
			var id = Guid.NewGuid();
			var command = new DeleteCheckInCommand(id);

			Assert.Equal(id, command.Id);
		}

		[Fact]
		public void Constructor_isPridate() {
			var command = (DeleteCheckInCommand)Activator.CreateInstance(typeof(DeleteCheckInCommand), true);


			Assert.Equal(Guid.Empty, command.Id);
		}

	}
}
