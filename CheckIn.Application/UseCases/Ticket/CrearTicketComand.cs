using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Ticket
{
    public class CrearTicketComand : IRequest<Guid>
    {
        public DateTime HoraReserva { get; set; }
        private CrearTicketComand()
        { }

        public CrearTicketComand(DateTime horaReserva)
        {
            HoraReserva = horaReserva;
        }
    }
}
