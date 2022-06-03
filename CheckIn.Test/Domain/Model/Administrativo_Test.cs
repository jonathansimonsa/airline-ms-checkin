using CheckIn.Domain.Model.Adm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Domain.Model
{
    public class Administrativo_Test
    {
        [Fact]
        public void Administrativo_CheckPropertiesValid()
        {
            var obj = new Administrativo();

            Assert.Equal(Guid.Empty, obj.Id);
            Assert.Null(obj.Ci);
            Assert.Null(obj.Nombres);
            Assert.Null(obj.Apellidos);
            Assert.Null(obj.Cargo);
        }
    }
}
