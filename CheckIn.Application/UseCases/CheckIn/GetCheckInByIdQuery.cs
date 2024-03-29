using CheckIn.Application.Dto.CheckIn;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.CheckIn {
	public class GetCheckInByIdQuery : IRequest<CheckInDto> {

		public Guid Id { get; set; }

		public GetCheckInByIdQuery(Guid id) {
			Id = id;
		}

		public GetCheckInByIdQuery() { }
	}
}
