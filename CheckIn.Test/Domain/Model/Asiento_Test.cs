using CheckIn.Domain.Model.Avion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Domain.Model
{
    public class Asiento_Test
    {
        [Fact]
        public void Asiento_CheckPropertiesValid()
        {
            var obj = new Asiento();

            Assert.Equal(Guid.Empty, obj.Id);
            Assert.Null(obj.Codigo);
            Assert.Equal(0, obj.Fila);
            Assert.Null(obj.Letra);
            Assert.Equal(0, obj.EsPrioridad);
        }
    }
}
