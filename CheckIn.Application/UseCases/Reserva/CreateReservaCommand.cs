using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Reserva {
	public class CreateReservaCommand : IRequest<Guid> {
		public Guid Id { get; set; }
		public DateTime Hora { get; set; }
		public Guid VueloId { get; set; }

		private CreateReservaCommand() { }

		public CreateReservaCommand(Guid id, DateTime hora, Guid vueloId) {
			Id = id;
			Hora = hora;
			VueloId = vueloId;
		}
	}
}
