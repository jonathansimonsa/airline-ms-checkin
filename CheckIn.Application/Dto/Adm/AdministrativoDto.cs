using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.Dto.Adm {
	public class AdministrativoDto {
		public Guid Id { get; set; }
		public string Ci { get; set; }
		public string Nombres { get; set; }
		public string Apellidos { get; set; }
		public string Cargo { get; set; }

		public AdministrativoDto() { }
	}
}
