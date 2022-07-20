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
			Assert.Equal(new DateTime(1, 1, 1, 0, 0, 0, 0), obj.HoraCheckIn);
			Assert.Equal(0, obj.EsAltaPrioridad);
			Assert.Equal(Guid.Empty, obj.TicketId);
			Assert.Equal(Guid.Empty, obj.AsientoId);
			Assert.Equal(Guid.Empty, obj.AdministrativoId);
			Assert.Equal(0, obj.DetalleEquipaje.Count);

			obj.ClearDomainEvents();
			Assert.Empty(obj.DomainEvents);


			obj.ResetEquipajes();
			Assert.Empty(obj.DetalleEquipaje);

			var valor = new CheckIn.Domain.Model.CheckIn.ValueObjects.NumeroCheckInValue("Codigo");
			string mytext = valor;

			Assert.NotNull(mytext);

			var new_Numero = new CheckIn.Domain.Model.CheckIn.ValueObjects.NumeroCheckInValue(".");
			new_Numero = "Nro";

			Assert.NotEqual(".", new_Numero.Value);

		}
	}
}
