using ShareKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.ShareKernel
{
   public class PersonNameValue_Test
    {
        [Fact]
        public void CheckValue() {

            var nombre = new PersonNameValue("Nombre");
            var obj = new {nombre  };

            Assert.Equal(nombre, obj.nombre);

            Assert.NotNull(nombre.Name);

            string myname = nombre;

            Assert.NotNull( myname);

            string jonathan = "Jonathan";
            nombre = jonathan;

            Assert.Equal(jonathan, nombre);

            try
            {
                nombre = new PersonNameValue("oiajsdodasmpdnuosbfnaspdoabfoasopdaopjqipweiqweipqfvpqwenpwiodjopqinwdpmdqipnqwodmpqwndiopqwopmdpgfurmqpdmoqwiuowecvpmqwpcqofoqwemqmipcnqweocmopwecpwenocqop,cqpevoqenomqcoqencpqeo`cqeipcvnoqecpqmcnqecpqeipcnqecpmqepibvnopqecm");
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
        }
    }
}
