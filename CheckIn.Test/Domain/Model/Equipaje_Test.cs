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
        }
    }
}
