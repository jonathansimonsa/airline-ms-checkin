using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Factories.Ticket {
	public class TicketFactory : ITicketFactory {
		public Model.Ticket.Ticket Create(DateTime horaReserva) {
			return new Model.Ticket.Ticket(horaReserva);
		}
	}
}
