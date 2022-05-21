using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Model.Ticket
{
    public class Ticket : AggregateRoot<Guid>
    {
        public DateTime HoraReserva { get; private set; }

        public Ticket() { }

        public Ticket(DateTime horaReserva)
        {
            Id = Guid.NewGuid();
            HoraReserva = horaReserva;
        }
    }
}
