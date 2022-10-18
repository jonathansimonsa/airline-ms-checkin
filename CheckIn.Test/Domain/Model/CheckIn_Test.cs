using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Domain.Model {
	public class CheckIn_Test {
		[Fact]
		public void CheckIn_CheckPropertiesValid() {
			var obj = new CheckIn.Domain.Model.CheckIn.CheckIn();

			Assert.Equal(Guid.Empty, obj.Id);
			Assert.Null(obj.NroCheckIn);
			Assert.Equal(new DateTime(1, 1, 1, 0, 0, 0, 0), obj.Hora);
			Assert.Equal(0, obj.EsAltaPrioridad);
			Assert.Null(obj.LetraAsiento);
			Assert.Equal(0, obj.NroAsiento);
			Assert.Equal(Guid.Empty, obj.ReservaId);
			Assert.Equal(0, obj.DetalleEquipaje.Count);

			obj.ClearDomainEvents();
			Assert.Empty(obj.DomainEvents);


			obj.ResetEquipajes();
			Assert.Empty(obj.DetalleEquipaje);

			var valor = new CheckIn.Domain.Model.CheckIn.ValueObjects.NumeroCheckInValue("C");
			string mytext = valor;

			Assert.NotNull(mytext);

			var new_Numero = new CheckIn.Domain.Model.CheckIn.ValueObjects.NumeroCheckInValue("Codigo");
			new_Numero = "Nro";
			Assert.NotEqual("Codigo", new_Numero.Value);


			obj = new CheckIn.Domain.Model.CheckIn.CheckIn("C-", DateTime.Now, 1, "P", 1, Guid.NewGuid(), Guid.NewGuid());
			obj.AgregarEquipaje("Bolso", new CheckIn.Domain.Model.CheckIn.ValueObjects.PesoValue(7), 1);

			obj.ConsolidarCheckIn();

		}
	}
}
