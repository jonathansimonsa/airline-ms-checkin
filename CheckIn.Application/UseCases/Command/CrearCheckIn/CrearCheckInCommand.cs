using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Command
{
    public class CrearCheckInCommand : IRequest<Guid>
    {
        private CrearCheckInCommand() { }

        public CrearCheckInCommand(int altaPrioridad, List<Dto.EquipajeDto> detalle)
        {
            AltaPrioridad = altaPrioridad;
            Detalle = detalle;
        }

        public int AltaPrioridad { get; set; }
        public List<Dto.EquipajeDto> Detalle { get; set; }


    }
}
