using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Ticket {
	public class CreateTicketCommand : IRequest<Guid> {
		public DateTime HoraReserva { get; set; }
		public Guid VueloId { get; set; }

		private CreateTicketCommand() { }

		public CreateTicketCommand(DateTime horaReserva, Guid vueloId) {
			HoraReserva = horaReserva;
			VueloId = vueloId;
		}
	}
}
