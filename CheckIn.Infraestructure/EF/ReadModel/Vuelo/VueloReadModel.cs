using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.ReadModel.Vuelo {
	public class VueloReadModel {
		public Guid Id { get; set; }
		public int NroVuelo { get; set; }
		public string Origen { get; set; }
		public string Destino { get; set; }

	}
}
