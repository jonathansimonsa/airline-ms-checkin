using CheckIn.Application.Dto.Adm;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Adm {
	public class GetAdmByIdQuery : IRequest<AdministrativoDto> {

		public Guid Id { get; set; }

		public GetAdmByIdQuery(Guid id) {
			Id = id;
		}

		public GetAdmByIdQuery() {

		}
	}
}
