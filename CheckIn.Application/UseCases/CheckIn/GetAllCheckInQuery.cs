using CheckIn.Application.Dto.CheckIn;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.CheckIn
{
    public class GetAllCheckInQuery : IRequest<List<CheckInDto>>
    {
        public GetAllCheckInQuery()
        { }
    }
}
