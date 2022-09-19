using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Factories.Vuelo {
	public class VueloFactory : IVueloFactory {
		public Model.Vuelo.Vuelo Create(Guid id, int nroVuelo, string origen, string destino) {
			return new Model.Vuelo.Vuelo(id, nroVuelo, origen, destino);
		}
	}
}
