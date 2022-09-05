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
	public class CreateTicketHandler : IRequestHandler<CreateTicketCommand, Guid> {
		private readonly ITicketRepository _ticketRepository;
		private readonly ILogger<CreateTicketHandler> _logger;
		private readonly ITicketFactory _ticketFactory;
		private readonly IUnitOfWork _unitOfWork;

		public CreateTicketHandler(ITicketRepository ticketRepository,
			ILogger<CreateTicketHandler> logger,
			ITicketFactory ticketFactory,
			IUnitOfWork unitOfWork) {
			_ticketRepository = ticketRepository;
			_logger = logger;
			_ticketFactory = ticketFactory;
			_unitOfWork = unitOfWork;
		}

		public async Task<Guid> Handle(CreateTicketCommand request, CancellationToken cancellationToken) {
			try {
				List<Domain.Model.Ticket.Ticket> lista = await _ticketRepository.GetAll();
				int newId = lista.Count + 1;

				Domain.Model.Ticket.Ticket objNuevo = _ticketFactory.Create(newId, request.HoraReserva, request.VueloId);

				await _ticketRepository.CreateAsync(objNuevo);
				await _unitOfWork.Commit();

				return objNuevo.Id;
			}
			catch (Exception ex) {
				_logger.LogError(ex, "Error al crear Ticket");
			}
			return Guid.Empty;
		}
	}
}
