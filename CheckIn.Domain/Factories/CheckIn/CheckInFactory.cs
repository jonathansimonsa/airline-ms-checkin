using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Factories.CheckIn {
	public class CheckInFactory : ICheckInFactory {
		public Model.CheckIn.CheckIn Create(string nroCheckIn, int esAltaPrioridad, string letraAsiento, int nroAsiento, Guid reservaId, Guid vueloId) {

			var obj = new Model.CheckIn.CheckIn(
				nroCheckIn,
				DateTime.Now,
				esAltaPrioridad,
				letraAsiento,
				nroAsiento,
				reservaId,
				vueloId);
			var objEvent = new Event.CheckInCreado(
				nroCheckIn,
				DateTime.Now,
				esAltaPrioridad,
				letraAsiento,
				nroAsiento,
				reservaId,
				vueloId);

			obj.AddDomainEvent(objEvent);

			return obj;
		}
	}
}
