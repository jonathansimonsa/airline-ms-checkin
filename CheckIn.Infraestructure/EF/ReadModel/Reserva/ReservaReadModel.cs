using CheckIn.Infraestructure.EF.ReadModel.Vuelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.ReadModel.Reserva {
	public class ReservaReadModel {
		public Guid Id { get; set; }
		public int NroReserva { get; set; }
		public DateTime Hora { get; set; }
		public VueloReadModel Vuelo { get; set; }

	}
}
