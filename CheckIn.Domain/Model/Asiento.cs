using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Model
{
    public class Asiento : Entity<Guid>
    {

        public int Fila { get; private set; }
        public string Letra { get; private set; }
        public int esPrioridad { get; private set; }

        public Asiento()
        {
        }

        public Asiento(int fila, string letra, int esPrioridad)
        {
            Id = Guid.NewGuid();
            Fila = fila;
            Letra = letra;
            this.esPrioridad = esPrioridad;
        }
    }
}
