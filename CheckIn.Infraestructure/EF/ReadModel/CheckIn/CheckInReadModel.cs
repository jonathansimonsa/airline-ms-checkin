using CheckIn.Infraestructure.EF.ReadModel.Adm;
using CheckIn.Infraestructure.EF.ReadModel.Avion;
using CheckIn.Infraestructure.EF.ReadModel.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.ReadModel.CheckIn {
	public class CheckInReadModel {
		public Guid Id { get; set; }
		public string NroCheckIn { get; set; }
		public DateTime HoraCheckIn { get; set; }
		public bool EsAltaPrioridad { get; set; }
		public TicketReadModel Ticket { get; set; }
		public AsientoReadModel Asiento { get; set; }
		public AdministrativoReadModel Administrativo { get; set; }

		public ICollection<EquipajeReadModel> DetalleEquipaje { get; set; }

		public CheckInReadModel() {
			DetalleEquipaje = new List<EquipajeReadModel>();
		}
	}
}
