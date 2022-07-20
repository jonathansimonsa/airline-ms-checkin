using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Factories.Avion {
	public class AsientoFactory : IAsientoFactory {
		public Model.Avion.Asiento Create(int fila, string letra, int esPrioridad) {
			return new Model.Avion.Asiento(fila, letra, esPrioridad);
		}

	}
}
