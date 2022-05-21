using CheckIn.Application.Dto.Ticket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Ticket
{
    public class GetAllTicketQuery : IRequest<List<TicketDto>>
    {
        public GetAllTicketQuery() { }
    }
}
