using CheckIn.Application.Dto.Ticket;
using CheckIn.Domain.Factories.Ticket;
using CheckIn.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Pedidos.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Ticket {
	public class DeleteTicketHandler : IRequestHandler<DeleteTicketCommand, Guid> {

		private readonly ITicketRepository _ticketRepository;
		private readonly ILogger<DeleteTicketHandler> _logger;
		private readonly ITicketFactory _ticketFactory;
		private readonly IUnitOfWork _unitOfWork;

		public DeleteTicketHandler(ITicketRepository ticketRepository,
			ILogger<DeleteTicketHandler> logger,
			ITicketFactory ticketFactory,
			IUnitOfWork unitOfWork) {
			_ticketRepository = ticketRepository;
			_logger = logger;
			_ticketFactory = ticketFactory;
			_unitOfWork = unitOfWork;
		}

		public async Task<Guid> Handle(DeleteTicketCommand request, CancellationToken cancellationToken) {
			try {
				Domain.Model.Ticket.Ticket obj = await _ticketRepository.FindByIdAsync(request.Id);

				if (obj == null) throw new Exception("Obj no encontrado.");

				await _ticketRepository.Deleteasync(obj);
				await _unitOfWork.Commit();

				return obj.Id;

			}
			catch (Exception ex) {
				_logger.LogError(ex, "Error al obtener el OBJ con id: " + request.Id);
			}
			return Guid.Empty;
		}
	}
}
