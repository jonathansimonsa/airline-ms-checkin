using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Factories.Reserva {
	public class ReservaFactory : IReservaFactory {
		public Model.Reserva.Reserva Create(Guid id, int nroReserva, DateTime hora, Guid vueloId) {
			return new Model.Reserva.Reserva(id, nroReserva, hora, vueloId);
		}
	}
}
