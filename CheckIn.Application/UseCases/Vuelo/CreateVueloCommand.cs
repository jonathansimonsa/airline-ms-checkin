using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Vuelo {
	public class CreateVueloCommand : IRequest<Guid> {
		public Guid Id { get; set; }
		public string Origen { get; set; }
		public string Destino { get; set; }
		private CreateVueloCommand() { }

		public CreateVueloCommand(Guid id, string origen, string destino) {
			Id = id;
			Origen = origen;
			Destino = destino;
		}
	}
}
