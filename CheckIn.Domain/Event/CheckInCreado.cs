using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Event {
	public record CheckInCreado : DomainEvent {
		public string NroCheckIn { get; }
		public DateTime HoraCheckIn { get; }
		public int EsAltaPrioridad { get; }
		public string LetraAsiento { get; set; }
		public int NroAsiento { get; set; }
		public Guid TicketId { get; }
		public Guid AdministrativoId { get; }

		public CheckInCreado(string nroCheckIn, DateTime horaCheckIn, int esAltaPrioridad, string letraAsiento, int nroAsiento, Guid ticketId, Guid administrativoId) : base(DateTime.Now) {
			NroCheckIn = nroCheckIn;
			HoraCheckIn = horaCheckIn;
			EsAltaPrioridad = esAltaPrioridad;
			LetraAsiento = letraAsiento;
			NroAsiento = nroAsiento;
			TicketId = ticketId;
			AdministrativoId = administrativoId;
		}
	}
}
