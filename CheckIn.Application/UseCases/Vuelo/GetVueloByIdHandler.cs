using Vuelo.Application.UseCases.Vuelo;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIn.Domain.Repositories;
using CheckIn.Application.Dto.Vuelo;
using CheckIn.Application.UseCases.Vuelo;
using System.Threading;
using CheckIn.Application.Dto.CheckIn;

namespace Vuelo.Application.UseCases.Vuelo {
	public class GetReservaByIdHandler : IRequestHandler<GetVueloByIdQuery, VueloDto> {
		private readonly IVueloRepository _vueloRepository;
		private readonly ILogger<GetReservaByIdHandler> _logger;

		public GetReservaByIdHandler(IVueloRepository vueloRepository, ILogger<GetReservaByIdHandler> logger) {
			_vueloRepository = vueloRepository;
			_logger = logger;
		}

		public async Task<VueloDto> Handle(GetVueloByIdQuery request, CancellationToken cancellationToken) {
			VueloDto result = null;
			try {
				CheckIn.Domain.Model.Vuelo.Vuelo obj = await _vueloRepository.FindByIdAsync(request.Id);

				result = new VueloDto() {
					Id = obj.Id,
					NroVuelo = obj.NroVuelo,
					Origen = obj.Origen,
					Destino = obj.Destino,
				};

			}
			catch (Exception ex) {
				_logger.LogError(ex, "Error al obtener Vuelo con id:", request.Id);
			}
			return result;
		}
	}
}
