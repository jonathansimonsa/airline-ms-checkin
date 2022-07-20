using CheckIn.Infraestructure.EF.ReadModel.CheckIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Infraestructure.ReadModel {
	public class EquipajeReadModel_Test {

		[Fact]
		public void CheckValidProps() {

			var id_Test = Guid.NewGuid();
			var desc_Test = "Descripcion #1";
			var peso_Test = (decimal)47.4;
			var esfragil_Test = 1;
			var checkin = new CheckInReadModel();

			var obj = new EquipajeReadModel();

			Assert.Equal(Guid.Empty, obj.Id);
			Assert.Null(obj.Descripcion);
			Assert.Equal(0, obj.Peso);
			Assert.Equal(0, obj.EsFragil);
			Assert.Null(obj.CheckIn);

			obj.Id = id_Test;
			obj.Descripcion = desc_Test;
			obj.Peso = peso_Test;
			obj.EsFragil = esfragil_Test;
			obj.CheckIn = checkin;

			Assert.Equal(id_Test, obj.Id);
			Assert.Equal(desc_Test, obj.Descripcion);
			Assert.Equal(peso_Test, obj.Peso);
			Assert.Equal(esfragil_Test, obj.EsFragil);
			Assert.Equal(checkin, obj.CheckIn);

		}
	}
}
