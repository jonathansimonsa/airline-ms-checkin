using ShareKernel.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.ShareKernel.IntegrationEvents {
	public class IntegrationReservaConfirmadaRollback_Test {

		[Fact]
		public void CheckValue() {
			var obj = new IntegrationReservaConfirmadaRollback(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

			Assert.NotNull(obj.reservaId);
			Assert.NotNull(obj.pagoId);
		}
	}
}
