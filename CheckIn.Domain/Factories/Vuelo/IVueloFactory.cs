using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Factories.Vuelo {
	public interface IVueloFactory {
		Model.Vuelo.Vuelo Create(int nroVuelo, string origen, string destino, DateTime partida, DateTime llegada);

	}
}
