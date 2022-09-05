using CheckIn.Application.Dto.Ticket;
using CheckIn.Application.Dto.Vuelo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Vuelo {
	public class GetAllVueloQuery : IRequest<List<VueloDto>> {
		public GetAllVueloQuery() { }
	}
}
