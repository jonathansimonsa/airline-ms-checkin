using CheckIn.Domain.Factories.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Factories.Vuelo {
	public class VueloFactory : IVueloFactory {
		public Model.Vuelo.Vuelo Create(int nroVuelo, string origen, string destino, DateTime partida, DateTime llegada) {
			return new Model.Vuelo.Vuelo(nroVuelo, origen, destino, partida, llegada);
		}
	}
}
