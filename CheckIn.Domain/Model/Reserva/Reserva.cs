using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Model.Reserva {
	public class Reserva : AggregateRoot<Guid> {
		public int NroReserva { get; private set; }
		public DateTime Hora { get; private set; }
		public Guid VueloId { get; private set; }

		public Reserva() { }

		public Reserva(Guid id, int nroReserva, DateTime hora, Guid vueloId) {
			Id = id;
			NroReserva = nroReserva;
			Hora = hora;
			VueloId = vueloId;
		}
	}
}
