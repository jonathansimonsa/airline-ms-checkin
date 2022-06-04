using CheckIn.Domain.Model.CheckIn;
using CheckIn.Domain.Model.CheckIn.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Domain.Model
{
    public class Equipaje_Test
    {
        [Fact]
        public void Equipaje_CheckPropertiesValid()
        {
            var obj = new Equipaje();

            Assert.Equal(Guid.Empty, obj.Id);
            Assert.Null(obj.Descripcion);
            Assert.Null(obj.Peso);
            Assert.Equal(0, obj.EsFragil);

            var valor = new PesoValue(55);
            decimal mydouble = valor;

            Assert.NotEqual(0, mydouble);

            var new_Peso = new PesoValue(0);
            new_Peso = 11;

            Assert.NotEqual(0, new_Peso);
            try
            {
                new_Peso = new PesoValue(-11);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }


        }
    }
}
