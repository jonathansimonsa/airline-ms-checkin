using CheckIn.Application.Dto.Adm;
using CheckIn.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Adm {
	public class GetAdmByIdHandler : IRequestHandler<GetAdmByIdQuery, AdministrativoDto> {

		private readonly IAdministrativoRepository _AdministrativoRepository;
		private readonly ILogger<GetAdmByIdHandler> _logger;

		public GetAdmByIdHandler(IAdministrativoRepository AdministrativoRepository, ILogger<GetAdmByIdHandler> logger) {
			_AdministrativoRepository = AdministrativoRepository;
			_logger = logger;
		}

		public async Task<AdministrativoDto> Handle(GetAdmByIdQuery request, CancellationToken cancellationToken) {
			AdministrativoDto result = null;
			try {
				Domain.Model.Adm.Administrativo obj = await _AdministrativoRepository.FindByIdAsync(request.Id);
				result = new AdministrativoDto() {
					Id = obj.Id,
					Ci = obj.Ci,
					Nombres = obj.Nombres,
					Apellidos = obj.Apellidos,
					Cargo = obj.Cargo,
				};
			}
			catch (Exception ex) {
				_logger.LogError(ex, "Error al obtener el OBJ con id: " + request.Id);
			}
			return result;
		}
	}
}
