using CheckIn.Infraestructure.EF.ReadModel.Avion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Infraestructure.ReadModel
{
    public class AsientoReadModel_Test
    {
        [Fact]
        public void CheckValidProps()
        {

            var id_Test = Guid.NewGuid();
            var codigo_Test = "123456789";
            var fila_Test = 3;
            var letra_Test = "A";
            var esPrioridad_Test = 1;

            var obj = new AsientoReadModel();

            Assert.Equal(Guid.Empty, obj.Id);
            Assert.Null(obj.Codigo);
            Assert.Equal(0, obj.Fila);
            Assert.Null(obj.Letra);
            Assert.Equal(0, obj.EsPrioridad);

            obj.Id = id_Test;
            obj.Codigo = codigo_Test;
            obj.Fila = fila_Test;
            obj.Letra = letra_Test;
            obj.EsPrioridad = esPrioridad_Test;

            Assert.Equal(id_Test, obj.Id);
            Assert.Equal(codigo_Test, obj.Codigo);
            Assert.Equal(fila_Test, obj.Fila);
            Assert.Equal(letra_Test, obj.Letra);
            Assert.Equal(esPrioridad_Test, obj.EsPrioridad);
        }

    }
}
