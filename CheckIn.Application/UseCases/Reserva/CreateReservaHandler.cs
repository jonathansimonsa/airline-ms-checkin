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
		private readonly IReservaFactory _reservaFactory;
		private readonly IUnitOfWork _unitOfWork;

		public CreateReservaHandler(IReservaRepository reservaRepository,
			ILogger<CreateReservaHandler> logger,
			IReservaFactory reservaFactory,
			IUnitOfWork unitOfWork) {
			_ticketRepository = reservaRepository;
			_logger = logger;
			_reservaFactory = reservaFactory;
			_unitOfWork = unitOfWork;
		}

		public async Task<Guid> Handle(CreateReservaCommand request, CancellationToken cancellationToken) {
			try {
				List<Domain.Model.Reserva.Reserva> lista = await _ticketRepository.GetAll();
				int newId = lista.Count + 1;

				Domain.Model.Reserva.Reserva objNuevo = _reservaFactory.Create(
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
