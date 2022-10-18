using CheckIn.Domain.Factories.Vuelo;
using CheckIn.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Vuelo {
	public class CreateVueloHandler : IRequestHandler<CreateVueloCommand, Guid> {
		private readonly IVueloRepository _vueloRepository;
		private readonly ILogger<CreateVueloHandler> _logger;
		private readonly IVueloFactory _vueloFactory;
		private readonly IUnitOfWork _unitOfWork;

		public CreateVueloHandler(IVueloRepository vueloRepository,
			ILogger<CreateVueloHandler> logger,
			IVueloFactory vueloFactory,
			IUnitOfWork unitOfWork) {
			_vueloRepository = vueloRepository;
			_logger = logger;
			_vueloFactory = vueloFactory;
			_unitOfWork = unitOfWork;
		}

		public async Task<Guid> Handle(CreateVueloCommand request, CancellationToken cancellationToken) {
			try {
				List<Domain.Model.Vuelo.Vuelo> lista = await _vueloRepository.GetAll();
				int newId = lista.Count + 1;

				Domain.Model.Vuelo.Vuelo objNuevo = _vueloFactory.Create(
					request.Id,
					newId,
					request.Origen,
					request.Destino);

				await _vueloRepository.CreateAsync(objNuevo);
				await _unitOfWork.Commit();

				return objNuevo.Id;
			}
			catch (Exception ex) {
				_logger.LogError(ex, "Error al crear Vuelo");
			}
			return Guid.Empty;
		}
	}
}
