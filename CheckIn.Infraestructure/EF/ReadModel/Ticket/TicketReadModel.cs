using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.ReadModel.Ticket
{
    public class TicketReadModel
    {
        public Guid Id { get; set; }
        public DateTime HoraReserva { get; set; }

    }
}
