using CheckIn.Domain.Model.Reserva;
using ShareKernel.Core;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.ShareKernel.Core {
	public class Entity_Test {

		[Fact]
		public void CheckValue() {
			Entity<Guid> obj = new Reserva();

			var myMock = new StringNotNullOrEmptyRule("Hola");
			var exception = new BussinessRuleValidationException(myMock);
			obj.CheckRule(exception.BrokenRule);

			obj.CheckRule(null);

			var myMock_2 = new StringNotNullOrEmptyRule(null);
			var exception_2 = new BussinessRuleValidationException(myMock_2);
			obj.CheckRule(exception_2.BrokenRule);
		}
	}
}
