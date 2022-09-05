using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Model.Ticket {
	public class Ticket : AggregateRoot<Guid> {
		public int NroTicket { get; private set; }
		public DateTime HoraReserva { get; private set; }
		public Guid VueloId { get; private set; }

		public Ticket() { }

		public Ticket(int nroTicket, DateTime horaReserva, Guid vueloId) {
			Id = Guid.NewGuid();
			NroTicket = nroTicket;
			HoraReserva = horaReserva;
			VueloId = vueloId;
		}
	}
}
