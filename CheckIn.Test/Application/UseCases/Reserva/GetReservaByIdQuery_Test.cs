using CheckIn.Application.UseCases.CheckIn;
using CheckIn.Application.UseCases.Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Application.UseCases {
	public class GetReservaByIdQuery_Test {

		[Fact]
		public void GetReservaByIdQuery_DataValid() {
			var id = Guid.NewGuid();
			var command = new GetReservaByIdQuery(id);

			Assert.Equal(id, command.Id);
		}

		[Fact]
		public void Constructor_isPridate() {
			var command = (GetReservaByIdQuery)Activator.CreateInstance(typeof(GetReservaByIdQuery), true);

			Assert.Equal(Guid.Empty, command.Id);
		}

	}
}
