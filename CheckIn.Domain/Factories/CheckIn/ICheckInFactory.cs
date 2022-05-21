using CheckIn.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Factories.CheckIn
{
    public interface ICheckInFactory
    {
        Model.CheckIn.CheckIn Create(string nroCheckIn, int esAltaPrioridad, 
            Guid ticketId, Guid asientoId, Guid administrativoId);
    }
}
