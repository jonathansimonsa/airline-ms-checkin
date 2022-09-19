using CheckIn.Domain.Factories.Vuelo;
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

namespace CheckIn.Application.UseCases.Vuelo {
	public class DeleteVueloHandler : IRequestHandler<DeleteVueloCommand, Guid> {

		private readonly IVueloRepository _vueloRepository;
		private readonly ILogger<DeleteVueloHandler> _logger;
		private readonly IVueloFactory _vueloFactory;
		private readonly IUnitOfWork _unitOfWork;

		public DeleteVueloHandler(IVueloRepository vueloRepository,
			ILogger<DeleteVueloHandler> logger,
			IVueloFactory vueloFactory,
			IUnitOfWork unitOfWork) {
			_vueloRepository = vueloRepository;
			_logger = logger;
			_vueloFactory = vueloFactory;
			_unitOfWork = unitOfWork;
		}

		public async Task<Guid> Handle(DeleteVueloCommand request, CancellationToken cancellationToken) {
			try {
				Domain.Model.Vuelo.Vuelo obj = await _vueloRepository.FindByIdAsync(request.Id);

				if (obj == null) throw new Exception("Obj no encontrado.");

				await _vueloRepository.Deleteasync(obj);
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
