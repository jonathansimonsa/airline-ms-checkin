using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.Dto.Ticket
{
    public class TicketDto
    {
        public Guid Id { get; set; }
        public DateTime HoraReserva { get; set; }

        public TicketDto()
        { }
    }
}
