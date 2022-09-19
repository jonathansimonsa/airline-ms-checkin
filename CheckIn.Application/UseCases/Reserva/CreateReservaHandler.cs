using CheckIn.Domain.Factories.Reserva;
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

namespace CheckIn.Application.UseCases.Reserva {
	public class CreateReservaHandler : IRequestHandler<CreateReservaCommand, Guid> {
		private readonly IReservaRepository _ticketRepository;
		private readonly ILogger<CreateReservaHandler> _logger;
		private readonly IReservaFactory _ticketFactory;
		private readonly IUnitOfWork _unitOfWork;

		public CreateReservaHandler(IReservaRepository ticketRepository,
			ILogger<CreateReservaHandler> logger,
			IReservaFactory ticketFactory,
			IUnitOfWork unitOfWork) {
			_ticketRepository = ticketRepository;
			_logger = logger;
			_ticketFactory = ticketFactory;
			_unitOfWork = unitOfWork;
		}

		public async Task<Guid> Handle(CreateReservaCommand request, CancellationToken cancellationToken) {
			try {
				List<Domain.Model.Reserva.Reserva> lista = await _ticketRepository.GetAll();
				int newId = lista.Count + 1;

				Domain.Model.Reserva.Reserva objNuevo = _ticketFactory.Create(
					request.Id,
					newId,
					request.Hora,
					request.VueloId);

				await _ticketRepository.CreateAsync(objNuevo);
				await _unitOfWork.Commit();

				return objNuevo.Id;
			}
			catch (Exception ex) {
				_logger.LogError(ex, "Error al crear Reserva");
			}
			return Guid.Empty;
		}
	}
}
