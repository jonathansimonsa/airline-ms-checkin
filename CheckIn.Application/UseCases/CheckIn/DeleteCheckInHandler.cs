using CheckIn.Application.UseCases.Adm;
using CheckIn.Domain.Factories.Adm;
using CheckIn.Domain.Factories.CheckIn;
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
	public class DeleteCheckInHandler : IRequestHandler<DeleteCheckInCommand, Guid> {

		private readonly ICheckInRepository _checkInRepository;
		private readonly ILogger<DeleteCheckInHandler> _logger;
		private readonly ICheckInFactory _checkInFactory;
		private readonly IUnitOfWork _unitOfWork;

		public DeleteCheckInHandler(ICheckInRepository checkInRepository,
			ILogger<DeleteCheckInHandler> logger,
			ICheckInFactory checkInFactory,
			IUnitOfWork unitOfWork) {
			_checkInRepository = checkInRepository;
			_logger = logger;
			_checkInFactory = checkInFactory;
			_unitOfWork = unitOfWork;
		}

		public async Task<Guid> Handle(DeleteCheckInCommand request, CancellationToken cancellationToken) {
			try {
				Domain.Model.CheckIn.CheckIn obj = await _checkInRepository.FindByIdAsync(request.Id);

				if (obj == null) throw new Exception("Obj no encontrado.");

				await _checkInRepository.Deleteasync(obj);
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
