using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.ShareKernel {
	public class NotNullRule_Test {
		[Fact]
		public void CheckValue() {
			var valor = "Exelsior";
			var myobj = new NotNullRule(valor);
			Assert.True(myobj.IsValid());
			Assert.NotNull(myobj.Message);
		}
	}
}
