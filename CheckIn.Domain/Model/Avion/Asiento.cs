using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Model.Avion {
	public class Asiento : AggregateRoot<Guid> {
		public string Codigo { get; private set; }
		public int Fila { get; private set; }
		public string Letra { get; private set; }
		public int EsPrioridad { get; private set; }

		public Asiento() { }

		public Asiento(int fila, string letra, int esPrioridad) {
			Id = Guid.NewGuid();
			Codigo = fila + "-" + letra;
			Fila = fila;
			Letra = letra;
			this.EsPrioridad = esPrioridad;
		}
	}
}
