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

namespace CheckIn.Application.UseCases.CheckIn
{
    public class CrearCheckInHandler : IRequestHandler<CrearCheckInCommand, Guid>
    {
        private readonly ICheckInRepository _checkInRepository;
        private readonly ILogger<CrearCheckInHandler> _logger;
        private readonly ICheckInService _checkInService;
        private readonly ICheckInFactory _checkInFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearCheckInHandler(ICheckInRepository checkInRepository,
            ILogger<CrearCheckInHandler> logger,
            ICheckInService checkInService,
            ICheckInFactory checkInFactory,
            IUnitOfWork unitOfWork)
        {
            _checkInRepository = checkInRepository;
            _logger = logger;
            _checkInService = checkInService;
            _checkInFactory = checkInFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearCheckInCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string nro = await _checkInService.GenerarNroCheckInAsync();
                Domain.Model.CheckIn.CheckIn objCheckIn = _checkInFactory.Create(nro, request.AltaPrioridad,
                    request.TicketId, request.AsientoId, request.AdministrativoId);

                foreach (var item in request.Detalle)
                {
                    objCheckIn.AgregarEquipaje(item.Descripcion, new PesoValue(item.Peso), item.EsFragil);
                }
                objCheckIn.ConsolidarCheckIn();

                await _checkInRepository.CreateAsync(objCheckIn);
                await _unitOfWork.Commit();

                return objCheckIn.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear CheckIn");
            }
            return Guid.Empty;
        }
    }
}
