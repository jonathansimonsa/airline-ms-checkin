using CheckIn.Application.UseCases.Reserva;
using CheckIn.Application.UseCases.Vuelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Application.UseCases {
	public class GetVueloByIdQuery_Test {

		[Fact]
		public void GetVueloByIdQuery_DataValid() {
			var id = Guid.NewGuid();
			var command = new GetVueloByIdQuery(id);

			Assert.Equal(id, command.Id);
		}

		[Fact]
		public void Constructor_isPridate() {
			var command = (GetVueloByIdQuery)Activator.CreateInstance(typeof(GetVueloByIdQuery), true);

			Assert.Equal(Guid.Empty, command.Id);
		}

	}
}
