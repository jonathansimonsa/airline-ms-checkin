using CheckIn.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Queries.GetAllCheckIn
{
    public class GetAllCheckInQuery : IRequest<List<CheckInDto>>
    {
        public GetAllCheckInQuery()
        {
        }
    }
}
