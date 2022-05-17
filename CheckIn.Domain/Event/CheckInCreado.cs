using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Event
{
    public record CheckInCreado : DomainEvent
    {
        public Guid Id { get; }
        public string NroCheckIn { get; }
        public DateTime HoraCheckIn { get; }
        public int EsAltaPrioridad { get; }

        public CheckInCreado(Guid id, string nroCheckIn,
                DateTime horaCheckIn, int esAltaPrioridad) : base(DateTime.Now)
        {
            Id = id;
            NroCheckIn = nroCheckIn;
            HoraCheckIn = horaCheckIn;
            EsAltaPrioridad = esAltaPrioridad;
        }

    }
}
