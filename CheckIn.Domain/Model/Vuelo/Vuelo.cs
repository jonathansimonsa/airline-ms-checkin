using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Model.Vuelo {
	public class Vuelo : AggregateRoot<Guid> {
		public int NroVuelo { get; private set; }
		public string Origen { get; private set; }
		public string Destino { get; private set; }

		public Vuelo() { }

		public Vuelo(Guid id, int nroVuelo, string origen, string destino) {
			Id = id;
			NroVuelo = nroVuelo;
			Origen = origen;
			Destino = destino;
		}
	}
}
