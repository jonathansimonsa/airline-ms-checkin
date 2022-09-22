using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.CheckIn {
	public class CreateCheckInCommand : IRequest<Guid> {

		public int EsAltaPrioridad { get; set; }
		public Guid ReservaId { get; set; }
		public List<Dto.CheckIn.EquipajeDto> Detalle { get; set; }

		private CreateCheckInCommand() { }

		public CreateCheckInCommand(int esAltaPrioridad, Guid reservaId, List<Dto.CheckIn.EquipajeDto> detalle) {
			EsAltaPrioridad = esAltaPrioridad;
			ReservaId = reservaId;
			Detalle = detalle;
		}

	}
}
