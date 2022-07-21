using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Model.Adm {
	public class Administrativo : AggregateRoot<Guid> {
		public string Ci { get; private set; }
		public string Nombres { get; private set; }
		public string Apellidos { get; private set; }
		public string Cargo { get; private set; }

		public Administrativo() { }

		public Administrativo(string ci, string nombres, string apellidos, string cargo) {
			Id = Guid.NewGuid();
			Ci = ci;
			Nombres = nombres;
			Apellidos = apellidos;
			Cargo = cargo;


			Cargo = cargo;
		}
	}
