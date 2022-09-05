using CheckIn.Application.Dto.Vuelo;
using CheckIn.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Vuelo {
	public class GetAllVueloHandler : IRequestHandler<GetAllVueloQuery, List<VueloDto>> {
		private readonly IVueloRepository _vueloRepository;
		private readonly ILogger<GetAllVueloHandler> _logger;

		public GetAllVueloHandler(IVueloRepository vueloRepository, ILogger<GetAllVueloHandler> logger) {
			_vueloRepository = vueloRepository;
			_logger = logger;
		}

		public async Task<List<VueloDto>> Handle(GetAllVueloQuery request, CancellationToken cancellationToken) {
			List<VueloDto> result = new List<VueloDto>();
			try {
				List<Domain.Model.Vuelo.Vuelo> lista = await _vueloRepository.GetAll();
				foreach (var obj in lista) {
					VueloDto nuevo = new VueloDto() {
						Id = obj.Id,
						NroVuelo = obj.NroVuelo,
						Origen = obj.Origen,
						Destino = obj.Destino,
						Partida = obj.Partida,
						Llegada = obj.Llegada,
					};
					result.Add(nuevo);
				}
			}
			catch (Exception ex) {
				_logger.LogError(ex, "Error al obtener Todos los Vuelos.");
			}
			return result.OrderBy(o => o.NroVuelo).ToList();
		}
	}
}
