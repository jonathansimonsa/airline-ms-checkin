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
	public class CreateAdmHandler : IRequestHandler<CreateAdmCommand, Guid> {

		private readonly IAdministrativoRepository _admRepository;
		private readonly ILogger<CreateAdmHandler> _logger;
		private readonly IAdministrativoFactory _admFactory;
		private readonly IUnitOfWork _unitOfWork;

		public CreateAdmHandler(IAdministrativoRepository admRepository,
			ILogger<CreateAdmHandler> logger,
			IAdministrativoFactory admFactory,
			IUnitOfWork unitOfWork) {
			_admRepository = admRepository;
			_logger = logger;
			_admFactory = admFactory;
			_unitOfWork = unitOfWork;
		}

		public async Task<Guid> Handle(CreateAdmCommand request, CancellationToken cancellationToken) {
			try {
				Domain.Model.Adm.Administrativo objNuevo = _admFactory.Create(
					request.Ci,
					request.Nombres,
					request.Apellidos,
					request.Cargo);

				await _admRepository.CreateAsync(objNuevo);
				await _unitOfWork.Commit();

				return objNuevo.Id;
			}
			catch (Exception ex) {
				_logger.LogError(ex, "Error al crear Administrativo");
			}
			return Guid.Empty;
		}
	}
}
