using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIn.Domain.Repositories;
using CheckIn.Application.Dto.Reserva;
using CheckIn.Application.UseCases.Reserva;
using System.Threading;
using CheckIn.Application.Dto.CheckIn;

namespace CheckIn.Application.UseCases.Reserva {
	public class GetReservaByIdHandler : IRequestHandler<GetReservaByIdQuery, ReservaDto> {
		private readonly IReservaRepository _reservaRepository;
		private readonly ILogger<GetReservaByIdHandler> _logger;

		public GetReservaByIdHandler(IReservaRepository reservaRepository, ILogger<GetReservaByIdHandler> logger) {
			_reservaRepository = reservaRepository;
			_logger = logger;
		}

		public async Task<ReservaDto> Handle(GetReservaByIdQuery request, CancellationToken cancellationToken) {
			ReservaDto result = null;
			try {
				Domain.Model.Reserva.Reserva obj = await _reservaRepository.FindByIdAsync(request.Id);

				result = new ReservaDto() {
					Id = obj.Id,
					NroReserva = obj.NroReserva,
					Hora = obj.Hora,
					VueloId = obj.VueloId,
				};

			}
			catch (Exception ex) {
				_logger.LogError(ex, "Error al obtener Reserva con id:", request.Id);
			}
			return result;
		}
	}
}
