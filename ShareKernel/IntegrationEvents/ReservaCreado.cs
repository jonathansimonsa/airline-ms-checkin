using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareKernel.IntegrationEvents {
	public record ReservaCreado : IntegrationEvent {
		public string reservaId { get; set; }
		public string hora { get; set; }
		public string vueloId { get; set; }
		public string origen { get; set; }
		public string destino { get; set; }
		public string pagoId { get; set; }
	}
}
