using CheckIn.Application.Dto.Adm;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Adm {
	public class GetAllAdmQuery : IRequest<List<AdministrativoDto>> {
		public GetAllAdmQuery() { }
	}
}
