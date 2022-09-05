using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Vuelo {
	public class CreateVueloComand : IRequest<Guid> {
		public string Origen { get; set; }
		public string Destino { get; set; }
		public DateTime Partida { get; set; }
		public DateTime Llegada { get; set; }

		private CreateVueloComand() { }

		public CreateVueloComand(string origen, string destino, DateTime partida, DateTime llegada) {
			Origen = origen;
			Destino = destino;
			Partida = partida;
			Llegada = llegada;
		}
	}
}
