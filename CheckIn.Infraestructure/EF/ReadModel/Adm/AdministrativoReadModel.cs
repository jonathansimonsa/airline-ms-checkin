using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.ReadModel.Adm {
	public class AdministrativoReadModel {
		public Guid Id { get; set; }
		public string Ci { get; set; }
		public string Nombres { get; set; }
		public string Apellidos { get; set; }
		public string Cargo { get; set; }

	}
}
