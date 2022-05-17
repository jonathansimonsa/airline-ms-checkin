using CheckIn.Domain.Model.ValueObjects;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Model
{
    public class Equipaje : Entity<Guid>
    {

        //TODO: Crear value objects para las propiedades
        public string Descripcion { get; private set; }
        public PesoValue Peso { get; private set; }
        public int EsFragil { get; private set; }

        public Equipaje()
        { }

        public Equipaje(string descripcion, PesoValue peso, int esFragil)
        {
            Id = Guid.NewGuid();
            Descripcion = descripcion;
            Peso = peso;
            EsFragil = esFragil;
        }

    }
}
