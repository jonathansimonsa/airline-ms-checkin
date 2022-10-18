using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Domain.Model {
	public class Vuelo_Test {
		[Fact]
		public void CheckPropertiesValid() {
			var obj = new CheckIn.Domain.Model.Vuelo.Vuelo();

			Assert.Equal(Guid.Empty, obj.Id);
			Assert.Equal(0, obj.NroVuelo);
			Assert.Null(obj.Origen);
			Assert.Null(obj.Destino);
		}
	}
}
