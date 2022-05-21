using CheckIn.Application.Dto.CheckIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Application.Dto
{
    public class EquipajeDto_Test
    {
        [Fact]
        public void EquipajeDto_CheckPropertiesValid()
        {
            var id_Test = Guid.NewGuid();
            var desc_Test = "Descripcion #1";
            var peso_Test = (decimal)47.4;
            var esfragil_Test = 1;

            var objEquipaje = new EquipajeDto();

            Assert.Equal(Guid.Empty, objEquipaje.Id);
            Assert.Null(objEquipaje.Descripcion);
            Assert.Equal(0, objEquipaje.Peso);
            Assert.Equal(0, objEquipaje.EsFragil);

            objEquipaje.Id = id_Test;
            objEquipaje.Descripcion = desc_Test;
            objEquipaje.Peso = peso_Test;
            objEquipaje.EsFragil = esfragil_Test;

            Assert.Equal(id_Test, objEquipaje.Id);
            Assert.Equal(desc_Test, objEquipaje.Descripcion);
            Assert.Equal(peso_Test, objEquipaje.Peso);
            Assert.Equal(esfragil_Test, objEquipaje.EsFragil);

        }

    }
}
