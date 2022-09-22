using CheckIn.Application.Dto.CheckIn;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Reserva {
	public class DeleteReservaCommand : IRequest<Guid> {

		public Guid Id { get; set; }

		public DeleteReservaCommand(Guid id) {
			Id = id;
		}
		public DeleteReservaCommand() { }
	}
}
