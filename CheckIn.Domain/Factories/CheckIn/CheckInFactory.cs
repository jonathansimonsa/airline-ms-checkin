using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Factories.CheckIn {
	public class CheckInFactory : ICheckInFactory {
		public Model.CheckIn.CheckIn Create(string nroCheckIn, int esAltaPrioridad, string letraAsiento, int nroAsiento,
			Guid ticketId, Guid vueloId, Guid administrativoId) {
			return new Model.CheckIn.CheckIn(nroCheckIn, esAltaPrioridad, letraAsiento, nroAsiento, ticketId, vueloId, administrativoId);
		}
	}
}
