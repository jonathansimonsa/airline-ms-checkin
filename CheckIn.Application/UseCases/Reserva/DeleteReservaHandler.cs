using CheckIn.Application.Dto.Reserva;
using CheckIn.Domain.Factories.Reserva;
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
	public class DeleteReservaHandler : IRequestHandler<DeleteReservaCommand, Guid> {

		private readonly IReservaRepository _reservaRepository;
		private readonly ILogger<DeleteReservaHandler> _logger;
		private readonly IReservaFactory _reservaFactory;
		private readonly IUnitOfWork _unitOfWork;

		public DeleteReservaHandler(IReservaRepository ticketRepository,
			ILogger<DeleteReservaHandler> logger,
			IReservaFactory ticketFactory,
			IUnitOfWork unitOfWork) {
			_reservaRepository = ticketRepository;
			_logger = logger;
			_reservaFactory = ticketFactory;
			_unitOfWork = unitOfWork;
		}

		public async Task<Guid> Handle(DeleteReservaCommand request, CancellationToken cancellationToken) {
			try {
				await _reservaRepository.Deleteasync(request.Id);
				await _unitOfWork.Commit();

				return request.Id;
			}
			catch (Exception ex) {
				_logger.LogError(ex, "Error al obtener el OBJ con id: " + request.Id);
			}
			return Guid.Empty;
		}
	}
}
