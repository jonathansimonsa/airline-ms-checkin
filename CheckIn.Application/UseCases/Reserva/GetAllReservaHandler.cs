using CheckIn.Application.Dto.Reserva;
using CheckIn.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Reserva {
	public class GetAllReservaHandler : IRequestHandler<GetAllReservaQuery, List<ReservaDto>> {
		private readonly IReservaRepository _ticketRepository;
		private readonly ILogger<GetAllReservaHandler> _logger;

		public GetAllReservaHandler(IReservaRepository ticketRepository, ILogger<GetAllReservaHandler> logger) {
			_ticketRepository = ticketRepository;
			_logger = logger;
		}

		public async Task<List<ReservaDto>> Handle(GetAllReservaQuery request, CancellationToken cancellationToken) {
			List<ReservaDto> result = new List<ReservaDto>();
			try {
				List<Domain.Model.Reserva.Reserva> lista = await _ticketRepository.GetAll();
				foreach (var obj in lista) {
					ReservaDto nuevo = new ReservaDto() {
						Id = obj.Id,
						NroReserva = obj.NroReserva,
						Hora = obj.Hora,
						VueloId = obj.VueloId,
					};
					result.Add(nuevo);
				}
			}
			catch (Exception ex) {
				_logger.LogError(ex, "Error al obtener Todos los Tickets.");
			}
			return result.OrderBy(o => o.NroReserva).ToList();
		}
	}
}
