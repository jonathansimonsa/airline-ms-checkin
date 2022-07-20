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
	public class GetAllAdmHandler : IRequestHandler<GetAllAdmQuery, List<AdministrativoDto>> {
		private readonly IAdministrativoRepository _administrativoRepository;
		private readonly ILogger<GetAllAdmQuery> _logger;

		public GetAllAdmHandler(IAdministrativoRepository administrativoRepository, ILogger<GetAllAdmQuery> logger) {
			_administrativoRepository = administrativoRepository;
			_logger = logger;
		}

		public async Task<List<AdministrativoDto>> Handle(GetAllAdmQuery request, CancellationToken cancellationToken) {
			List<AdministrativoDto> result = new List<AdministrativoDto>();
			try {
				List<Domain.Model.Adm.Administrativo> lista = await _administrativoRepository.GellAll();
				foreach (var obj in lista) {
					AdministrativoDto nuevo = new AdministrativoDto() {
						Id = obj.Id,
						Ci = obj.Ci,
						Nombres = obj.Nombres,
						Apellidos = obj.Apellidos,
						Cargo = obj.Cargo,
					};
					result.Add(nuevo);
				}
			}
			catch (Exception ex) {
				_logger.LogError(ex, "Error al obtener Todos los Adms.");
			}
			return result;
		}
	}
}
