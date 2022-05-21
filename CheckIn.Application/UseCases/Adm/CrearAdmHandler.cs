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

namespace CheckIn.Application.UseCases.Adm
{
    public class CrearAdmHandler : IRequestHandler<CrearAdmCommand, Guid>
    {
        private readonly IAdministrativoRepository _checkInRepository;
        private readonly ILogger<CrearAdmHandler> _logger;
        private readonly IAdministrativoFactory _checkInFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearAdmHandler(IAdministrativoRepository checkInRepository,
            ILogger<CrearAdmHandler> logger,
            IAdministrativoFactory checkInFactory,
            IUnitOfWork unitOfWork)
        {
            _checkInRepository = checkInRepository;
            _logger = logger;
            _checkInFactory = checkInFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearAdmCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Domain.Model.Adm.Administrativo objNuevo = _checkInFactory.Create(
                    request.Ci,
                    request.Nombres,
                    request.Apellidos,
                    request.Cargo);

                await _checkInRepository.CreateAsync(objNuevo);
                await _unitOfWork.Commit();

                return objNuevo.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear Administrativo");
            }
            return Guid.Empty;
        }
    }
}
