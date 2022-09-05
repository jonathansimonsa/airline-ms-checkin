using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.Dto.Vuelo {
	public class VueloDto {
		public Guid Id { get; set; }
		public int NroVuelo { get; set; }
		public string Origen { get; set; }
		public string Destino { get; set; }
		public DateTime Partida { get; set; }
		public DateTime Llegada { get; set; }

		public VueloDto() {
		}
	}
}
