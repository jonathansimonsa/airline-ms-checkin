using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.ShareKernel
{
    public class StringNotNullOrEmptyRule_Test
    {
        [Fact]
        public void CheckValue()
        {
            var valor = "CheckValue";
            var myobj = new StringNotNullOrEmptyRule(valor);
            Assert.True(myobj.IsValid());
            Assert.NotNull(myobj.Message);

            valor = null;
            myobj = new StringNotNullOrEmptyRule(valor);
            Assert.False(myobj.IsValid());
        }
    }
}
