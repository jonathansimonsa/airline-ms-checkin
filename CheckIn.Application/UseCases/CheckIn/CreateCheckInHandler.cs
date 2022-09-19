using CheckIn.Application.Services;
using CheckIn.Domain.Factories.CheckIn;
using CheckIn.Domain.Model.CheckIn.ValueObjects;
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

namespace CheckIn.Application.UseCases.CheckIn {
	public class CreateCheckInHandler : IRequestHandler<CreateCheckInCommand, Guid> {
		private readonly ICheckInRepository _checkInRepository;
		private readonly ILogger<CreateCheckInHandler> _logger;
		private readonly ICheckInService _checkInService;
		private readonly ICheckInFactory _checkInFactory;
		private readonly IUnitOfWork _unitOfWork;

		private readonly IReservaRepository _reservaRepository;

		public CreateCheckInHandler(ICheckInRepository checkInRepository,
			ILogger<CreateCheckInHandler> logger,
			ICheckInService checkInService,
			ICheckInFactory checkInFactory,
			IUnitOfWork unitOfWork,
			IReservaRepository reservaRepository) {
			_checkInRepository = checkInRepository;
			_logger = logger;
			_checkInService = checkInService;
			_checkInFactory = checkInFactory;
			_unitOfWork = unitOfWork;
			_reservaRepository = reservaRepository;
		}

		public async Task<Guid> Handle(CreateCheckInCommand request, CancellationToken cancellationToken) {
			try {
				var checkTicket_lista = await _checkInRepository.GetByReservaId(request.ReservaId);
				if (checkTicket_lista.Any()) throw new Exception("Ya existe un check in registrado con este Ticket.");


				List<Domain.Model.CheckIn.CheckIn> lista = await _checkInRepository.GetAll();
				var newId = lista.Count + 1;

				string nro = await _checkInService.GenerarNroCheckInAsync();

				Domain.Model.Reserva.Reserva ticket_obj = await _reservaRepository.FindByIdAsync(request.ReservaId);
				if (ticket_obj == null) throw new Exception("Ticket no encontrado.");
				var vueloId = ticket_obj.VueloId;

				var checkVuelo_lista = await _checkInRepository.GetByVueloAndPrioridad(vueloId, request.EsAltaPrioridad);

				var nroAsiento = checkVuelo_lista.Count + 1;

				var subId = checkTicket_lista.Count + 1;

				Domain.Model.CheckIn.CheckIn objCheckIn = _checkInFactory.Create(nro + newId + "-CV-" + subId,
					request.EsAltaPrioridad,
					request.EsAltaPrioridad == 1 ? "P" : "N",
					nroAsiento,
					request.ReservaId,
					vueloId);

				foreach (var item in request.Detalle) {
					objCheckIn.AgregarEquipaje(item.Descripcion, new PesoValue(item.Peso), item.EsFragil);
				}
				objCheckIn.ConsolidarCheckIn();

				await _checkInRepository.CreateAsync(objCheckIn);
				await _unitOfWork.Commit();

				return objCheckIn.Id;
			}
			catch (Exception ex) {
				_logger.LogError(ex, "Error al crear CheckIn");
			}
			return Guid.Empty;
		}
	}
}
