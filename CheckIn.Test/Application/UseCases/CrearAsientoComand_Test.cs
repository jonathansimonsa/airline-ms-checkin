using CheckIn.Application.UseCases.Avion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Application.UseCases
{
    public class CrearAsientoComand_Test
    {

        [Fact]
        public void CrearAsientoCommand_DataValid()
        {
            var fila = 11;
            var letra = "D";
            var esPrioridad = 1;
            var command = new CrearAsientoComand(fila, letra, esPrioridad);

            Assert.Equal(fila, command.Fila);
            Assert.Equal(letra, command.Letra);
            Assert.Equal(esPrioridad, command.EsPrioridad);
        }

        [Fact]
        public void Constructor_isPridate()
        {
            var command = (CrearAsientoComand)Activator.CreateInstance(typeof(CrearAsientoComand), true);

            Assert.Equal(0, command.Fila);
            Assert.Null(command.Letra);
            Assert.Equal(0, command.EsPrioridad);
        }
    }
}
