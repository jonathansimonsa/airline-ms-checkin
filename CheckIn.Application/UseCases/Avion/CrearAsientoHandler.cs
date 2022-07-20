using CheckIn.Domain.Factories.Avion;
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

namespace CheckIn.Application.UseCases.Avion {
	public class CrearAsientoHandler : IRequestHandler<CrearAsientoComand, Guid> {
		private readonly IAsientoRepository _asientoRepository;
		private readonly ILogger<CrearAsientoHandler> _logger;
		private readonly IAsientoFactory _asientoFactory;
		private readonly IUnitOfWork _unitOfWork;

		public CrearAsientoHandler(IAsientoRepository asientoRepository,
			ILogger<CrearAsientoHandler> logger,
			IAsientoFactory asientoFactory,
			IUnitOfWork unitOfWork) {
			_asientoRepository = asientoRepository;
			_logger = logger;
			_asientoFactory = asientoFactory;
			_unitOfWork = unitOfWork;
		}

		public async Task<Guid> Handle(CrearAsientoComand request, CancellationToken cancellationToken) {

			try {
				Domain.Model.Avion.Asiento objNuevo = _asientoFactory.Create(
					request.Fila,
					request.Letra,
					request.EsPrioridad);

				await _asientoRepository.CreateAsync(objNuevo);
				await _unitOfWork.Commit();

				return objNuevo.Id;
			}
			catch (Exception ex) {
				_logger.LogError(ex, "Error al crear Asiento");
			}
			return Guid.Empty;
		}
	}
}
