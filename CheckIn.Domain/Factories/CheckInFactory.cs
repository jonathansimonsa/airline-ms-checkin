using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Factories
{
    public class CheckInFactory : ICheckInFactory
    {
        public Model.CheckIn Create(string nroCheckIn, int esAltaPrioridad)
        {
            return new Model.CheckIn(nroCheckIn, esAltaPrioridad);
        }
    }
}
