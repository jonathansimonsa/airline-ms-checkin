using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.CheckIn {
	public class CrearCheckInCommand : IRequest<Guid> {

		public int AltaPrioridad { get; set; }
		public Guid TicketId { get; set; }
		public Guid AsientoId { get; set; }
		public Guid AdministrativoId { get; set; }
		public List<Dto.CheckIn.EquipajeDto> Detalle { get; set; }

		private CrearCheckInCommand() { }

		public CrearCheckInCommand(int altaPrioridad, Guid ticketId, Guid asientoId, Guid administrativoId, List<Dto.CheckIn.EquipajeDto> detalle) {
			AltaPrioridad = altaPrioridad;
			TicketId = ticketId;
			AsientoId = asientoId;
			AdministrativoId = administrativoId;
			Detalle = detalle;
		}

	}
}
