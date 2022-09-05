using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.CheckIn {
	public class DeleteCheckInCommand : IRequest<Guid> {

		public Guid Id { get; set; }

		public DeleteCheckInCommand(Guid id) {
			Id = id;
		}
		public DeleteCheckInCommand() { }
	}
}
