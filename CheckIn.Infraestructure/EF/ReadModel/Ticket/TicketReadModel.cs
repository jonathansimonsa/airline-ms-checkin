using CheckIn.Infraestructure.EF.ReadModel.Vuelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.ReadModel.Ticket {
	public class TicketReadModel {
		public Guid Id { get; set; }
		public int NroTicket { get; set; }
		public DateTime HoraReserva { get; set; }
		public VueloReadModel Vuelo { get; set; }

	}
}
