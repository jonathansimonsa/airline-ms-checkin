using CheckIn.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.Dto
{
    public class CheckInDto
    {
        public Guid Id { get; set; }
        public string NroCheckIn { get; set; }
        public DateTime HoraCheckIn { get; set; }
        public int EsAltaPrioridad { get; set; }
        public ICollection<EquipajeDto> DetalleEquipaje { get; set; }

        public CheckInDto()
        {
            DetalleEquipaje = new List<EquipajeDto>();
        }
    }
}
