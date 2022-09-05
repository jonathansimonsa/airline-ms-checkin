using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Adm {
	public class CreateAdmCommand : IRequest<Guid> {
		public string Ci { get; set; }
		public string Nombres { get; set; }
		public string Apellidos { get; set; }
		public string Cargo { get; set; }

		private CreateAdmCommand() { }

		public CreateAdmCommand(string ci, string nombres, string apellidos, string cargo) {
			Ci = ci;
			Nombres = nombres;
			Apellidos = apellidos;
			Cargo = cargo;
		}
	}
}
