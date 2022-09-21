using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareKernel.IntegrationEvents {
	public class IntegrationReservaConfirmadaRollback {
		public string reservaId { get; set; }
		public string pagoId { get; set; }

		public IntegrationReservaConfirmadaRollback(string reservaId, string pagoId) {
			this.reservaId = reservaId;
			this.pagoId = pagoId;
		}
	}
}
