using CheckIn.Infraestructure.EF.ReadModel.Adm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Infraestructure.ReadModel {
	public class AdministrativoReadModel_Test {
		[Fact]
		public void CheckValidProps() {
			var id_Test = Guid.NewGuid();
			var ci_Test = "1234567";
			var nombres_Test = "Nombres";
			var apellidos_Test = "Apellidos";
			var cargo_Test = "Cargo";

			var obj = new AdministrativoReadModel();

			Assert.Equal(Guid.Empty, obj.Id);
			Assert.Null(obj.Ci);
			Assert.Null(obj.Nombres);
			Assert.Null(obj.Apellidos);
			Assert.Null(obj.Cargo);

			obj.Id = id_Test;
			obj.Ci = ci_Test;
			obj.Nombres = nombres_Test;
			obj.Apellidos = apellidos_Test;
			obj.Cargo = cargo_Test;

			Assert.Equal(id_Test, obj.Id);
			Assert.Equal(ci_Test, obj.Ci);
			Assert.Equal(nombres_Test, obj.Nombres);
			Assert.Equal(apellidos_Test, obj.Apellidos);
			Assert.Equal(cargo_Test, obj.Cargo);
		}
	}
}
