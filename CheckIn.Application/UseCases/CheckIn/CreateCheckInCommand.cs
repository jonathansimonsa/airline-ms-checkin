using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.CheckIn {
	public class CreateCheckInCommand : IRequest<Guid> {

		public int EsAltaPrioridad { get; set; }
		public Guid TicketId { get; set; }
		public Guid AdministrativoId { get; set; }
		public List<Dto.CheckIn.EquipajeDto> Detalle { get; set; }

		private CreateCheckInCommand() { }

		public CreateCheckInCommand(int esAltaPrioridad, Guid ticketId, Guid administrativoId, List<Dto.CheckIn.EquipajeDto> detalle) {
			EsAltaPrioridad = esAltaPrioridad;
			TicketId = ticketId;
			AdministrativoId = administrativoId;
			Detalle = detalle;
		}

	}
}
