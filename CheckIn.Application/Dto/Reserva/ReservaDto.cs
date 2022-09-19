using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.Dto.Reserva {
	public class ReservaDto {
		public Guid Id { get; set; }
		public int NroReserva { get; set; }
		public DateTime Hora { get; set; }
		public Guid VueloId { get; set; }

		public ReservaDto() { }
	}
}
