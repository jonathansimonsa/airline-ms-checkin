using CheckIn.Domain.Factories.Ticket;
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

namespace CheckIn.Application.UseCases.Ticket
{
    public class CrearTicketHandler : IRequestHandler<CrearTicketComand, Guid>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ILogger<CrearTicketHandler> _logger;
        private readonly ITicketFactory _ticketFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearTicketHandler(ITicketRepository ticketRepository,
            ILogger<CrearTicketHandler> logger,
            ITicketFactory ticketFactory,
            IUnitOfWork unitOfWork)
        {
            _ticketRepository = ticketRepository;
            _logger = logger;
            _ticketFactory = ticketFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearTicketComand request, CancellationToken cancellationToken)
        {
            try
            {
                Domain.Model.Ticket.Ticket objNuevo = _ticketFactory.Create(request.HoraReserva);

                await _ticketRepository.CreateAsync(objNuevo);
                await _unitOfWork.Commit();

                return objNuevo.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear Ticket");
            }
            return Guid.Empty;
        }
    }
}
