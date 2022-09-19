using CheckIn.Infraestructure.EF.ReadModel.Reserva;
using CheckIn.Infraestructure.EF.ReadModel.Vuelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.ReadModel.CheckIn {
	public class CheckInReadModel {
		public Guid Id { get; set; }
		public string NroCheckIn { get; set; }
		public DateTime Hora { get; set; }
		public int EsAltaPrioridad { get; set; }
		public string LetraAsiento { get; set; }
		public int NroAsiento { get; set; }
		public ReservaReadModel Reserva { get; set; }
		public VueloReadModel Vuelo { get; set; }

		public ICollection<EquipajeReadModel> DetalleEquipaje { get; set; }

		public CheckInReadModel() {
			DetalleEquipaje = new List<EquipajeReadModel>();
		}
	}
}
