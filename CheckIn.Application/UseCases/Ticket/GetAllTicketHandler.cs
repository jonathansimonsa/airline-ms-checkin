using CheckIn.Application.Dto.Ticket;
using CheckIn.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Ticket {
	public class GetAllTicketHandler : IRequestHandler<GetAllTicketQuery, List<TicketDto>> {
		private readonly ITicketRepository _ticketRepository;
		private readonly ILogger<GetAllTicketHandler> _logger;

		public GetAllTicketHandler(ITicketRepository ticketRepository, ILogger<GetAllTicketHandler> logger) {
			_ticketRepository = ticketRepository;
			_logger = logger;
		}

		public async Task<List<TicketDto>> Handle(GetAllTicketQuery request, CancellationToken cancellationToken) {
			List<TicketDto> result = new List<TicketDto>();
			try {
				List<Domain.Model.Ticket.Ticket> lista = await _ticketRepository.GetAll();
				foreach (var obj in lista) {
					TicketDto nuevo = new TicketDto() {
						Id = obj.Id,
						NroTicket = obj.NroTicket,
						HoraReserva = obj.HoraReserva,
						VueloId = obj.VueloId,
					};
					result.Add(nuevo);
				}
			}
			catch (Exception ex) {
				_logger.LogError(ex, "Error al obtener Todos los Tickets.");
			}
			return result.OrderBy(o => o.NroTicket).ToList();
		}
	}
}
