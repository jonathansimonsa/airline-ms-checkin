using CheckIn.Application.Dto.Adm;
using CheckIn.Domain.Factories.Adm;
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

namespace CheckIn.Application.UseCases.Adm {
	public class DeleteAdmHandler : IRequestHandler<DeleteAdmCommand, Guid> {

		private readonly IAdministrativoRepository _admRepository;
		private readonly ILogger<DeleteAdmHandler> _logger;
		private readonly IAdministrativoFactory _admFactory;
		private readonly IUnitOfWork _unitOfWork;

		public DeleteAdmHandler(IAdministrativoRepository admRepository,
			ILogger<DeleteAdmHandler> logger,
			IAdministrativoFactory admFactory,
			IUnitOfWork unitOfWork) {
			_admRepository = admRepository;
			_logger = logger;
			_admFactory = admFactory;
			_unitOfWork = unitOfWork;
		}

		public async Task<Guid> Handle(DeleteAdmCommand request, CancellationToken cancellationToken) {
			try {
				Domain.Model.Adm.Administrativo obj = await _admRepository.FindByIdAsync(request.Id);

				if (obj == null) throw new Exception("Obj no encontrado.");

				await _admRepository.Deleteasync(obj);
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
