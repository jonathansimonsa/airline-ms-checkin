using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Factories.Avion
{
    public interface IAsientoFactory
    {
        Model.Avion.Asiento Create(int fila, string letra, int esPrioridad);
    }
}
