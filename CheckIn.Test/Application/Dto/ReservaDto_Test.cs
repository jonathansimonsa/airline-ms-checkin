using CheckIn.Application.Dto.Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Application.Dto {
	public class ReservaDto_Test {
		[Fact]
		public void TicketDto_CheckPropertiesValid() {
			var id_Test = Guid.NewGuid();
			var hora_Test = DateTime.Now;

			var obj = new ReservaDto();

			Assert.Equal(Guid.Empty, obj.Id);
			Assert.Equal(new DateTime(1, 1, 1, 0, 0, 0, 0), obj.Hora);

			obj.Id = id_Test;
			obj.Hora = hora_Test;

			Assert.Equal(id_Test, obj.Id);
			Assert.Equal(hora_Test, obj.Hora);
		}
	}
}
