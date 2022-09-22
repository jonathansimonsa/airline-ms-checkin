using CheckIn.Application.Dto.CheckIn;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Vuelo {
	public class DeleteVueloCommand : IRequest<Guid> {

		public Guid Id { get; set; }

		public DeleteVueloCommand(Guid id) {
			Id = id;
		}
		public DeleteVueloCommand() { }
	}
}
