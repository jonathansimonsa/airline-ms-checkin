using CheckIn.Application.Dto.Reserva;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Reserva {
	public class GetReservaByIdQuery : IRequest<ReservaDto> {

		public Guid Id { get; set; }

		public GetReservaByIdQuery(Guid id) {
			Id = id;
		}

		public GetReservaByIdQuery() { }
	}
}
