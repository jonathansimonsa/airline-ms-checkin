using CheckIn.Domain.Factories.Adm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Domain.Factory {
	public class AdministrativoFactory_Test {
		[Fact]
		public void Create_Correctly() {
			string ci_test = "1234567";
			string nombres_test = "Fabio";
			string apellidos_test = "Cosio";
			string cargo_test = "Vendedor";
			var factory = new AdministrativoFactory();
			var obj = factory.Create(ci_test, nombres_test, apellidos_test, cargo_test);

			Assert.NotNull(obj);
			Assert.Equal(ci_test, obj.Ci);
			Assert.Equal(nombres_test, obj.Nombres);
			Assert.Equal(apellidos_test, obj.Apellidos);
			Assert.Equal(cargo_test, obj.Cargo);

		}

	}
}
