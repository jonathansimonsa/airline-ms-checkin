using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.ReadModel
{
    public class CheckInReadModel
    {
        public Guid Id { get; set; }
        public string NroCheckIn { get; set; }
        public DateTime HoraCheckIn { get; set; }
        public bool EsAltaPrioridad { get; set; }

        public ICollection<EquipajeReadModel> DetalleEquipaje;

        public CheckInReadModel()
        { }
    }
}
