using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.ShareKernel {
	public class DoubleNotNullOrNegaviteRule_Test {
		[Fact]
		public void CheckValue() {
			var valor = 25.5;
			var mydouble = new DoubleNotNullOrNegaviteRule(valor);
			Assert.True(mydouble.IsValid());
			Assert.NotNull(mydouble.Message);

			valor = -1;
			mydouble = new DoubleNotNullOrNegaviteRule(valor);

			Assert.False(mydouble.IsValid());

		}
	}
}
