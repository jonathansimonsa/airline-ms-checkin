using CheckIn.Application.Dto.Reserva;
using CheckIn.Application.UseCases.Reserva;
using CheckIn.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.ReservaLibre {
	public class GetAllReservaLibreHandler : IRequestHandler<GetAllReservaLibreQuery, List<ReservaDto>> {
		private readonly IReservaRepository _reservaRepository;
		private readonly ICheckInRepository _checkInRepository;
		private readonly ILogger<GetAllReservaLibreHandler> _logger;

		public GetAllReservaLibreHandler(IReservaRepository reservaRepository, ICheckInRepository checkInRepository, ILogger<GetAllReservaLibreHandler> logger) {
			_reservaRepository = reservaRepository;
			_checkInRepository = checkInRepository;
			_logger = logger;
		}

		public async Task<List<ReservaDto>> Handle(GetAllReservaLibreQuery request, CancellationToken cancellationToken) {
			var result = new List<ReservaDto>();
			try {
				var lista_reservas = await _reservaRepository.GetAll();
				var lista_checkIn = await _checkInRepository.GetAll();

				foreach (var r in lista_reservas) {
					int cant = 0;
					foreach (var c in lista_checkIn) {
						if (r.Id.Equals(c.ReservaId))
							cant++;
					}
					if (cant == 0)
						result.Add(new ReservaDto() {
							Id = r.Id,
							NroReserva = r.NroReserva,
							Hora = r.Hora,
							VueloId = r.VueloId
						});
				}
			}
			catch (Exception ex) {
				_logger.LogError(ex, "Error GetAllReservaLibreHandler");
			}
			return result.OrderBy(o => o.NroReserva).ToList();
		}
	}
}
