using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Avion {
	public class CrearAsientoComand : IRequest<Guid> {
		public int Fila { get; set; }
		public string Letra { get; set; }
		public int EsPrioridad { get; set; }

		private CrearAsientoComand() { }

		public CrearAsientoComand(int fila, string letra, int esPrioridad) {
			Fila = fila;
			Letra = letra;
			EsPrioridad = esPrioridad;
		}
	}
}
