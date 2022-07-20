using CheckIn.Application.Dto.Avion;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Avion {
	public class GetAllAsientoQuery : IRequest<List<AsientoDto>> {
		public GetAllAsientoQuery() { }
	}
}
