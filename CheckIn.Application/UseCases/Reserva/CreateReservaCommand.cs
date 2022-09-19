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
		public Guid PagoId { get; set; }

		private CreateReservaCommand() { }

		public CreateReservaCommand(Guid id, DateTime hora, Guid vueloId, Guid pagoId) {
			Id = id;
			Hora = hora;
			VueloId = vueloId;
			PagoId = pagoId;
		}
	}
}
