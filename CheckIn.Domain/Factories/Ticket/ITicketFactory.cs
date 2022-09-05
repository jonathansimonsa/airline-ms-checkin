using CheckIn.Domain.Model.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Factories.Ticket {
	public interface ITicketFactory {
		Model.Ticket.Ticket Create(int nroTicket, DateTime horaReserva, Guid vueloId);
	}
}
