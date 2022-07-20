using CheckIn.Domain.Factories.Avion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Domain.Factory {
	public class AsientoFactory_Test {
		[Fact]
		public void Create_Correctly() {
			int fila_test = 11;
			string letra_test = "D";
			int prioridad_test = 1;

			var factory = new AsientoFactory();
			var obj = factory.Create(fila_test, letra_test, prioridad_test);

			Assert.NotNull(obj);
			Assert.Equal(fila_test, obj.Fila);
			Assert.Equal(letra_test, obj.Letra);
			Assert.Equal(prioridad_test, obj.EsPrioridad);
		}
	}
}
