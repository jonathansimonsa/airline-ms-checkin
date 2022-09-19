using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Event {
	public record CheckInCreado : DomainEvent {
		public string NroCheckIn { get; }
		public DateTime Hora { get; }
		public int EsAltaPrioridad { get; }
		public string LetraAsiento { get; set; }
		public int NroAsiento { get; set; }
		public Guid ReservaId { get; }
		public Guid VueloId { get; }

		public CheckInCreado(string nroCheckIn, DateTime hora, int esAltaPrioridad, string letraAsiento, int nroAsiento, Guid reservaId, Guid vueloId) : base(hora) {
			NroCheckIn = nroCheckIn;
			Hora = hora;
			EsAltaPrioridad = esAltaPrioridad;
			LetraAsiento = letraAsiento;
			NroAsiento = nroAsiento;
			ReservaId = reservaId;
			VueloId = vueloId;
		}
	}
}
