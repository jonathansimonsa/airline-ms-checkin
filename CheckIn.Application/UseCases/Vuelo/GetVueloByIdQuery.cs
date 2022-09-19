using CheckIn.Application.Dto.Vuelo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Vuelo {
	public class GetVueloByIdQuery : IRequest<VueloDto> {

		public Guid Id { get; set; }

		public GetVueloByIdQuery(Guid id) {
			Id = id;
		}

		public GetVueloByIdQuery() { }
	}
}
