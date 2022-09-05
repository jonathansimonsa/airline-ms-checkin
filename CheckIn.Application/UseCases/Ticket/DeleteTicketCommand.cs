using CheckIn.Application.Dto.Adm;
using CheckIn.Application.Dto.CheckIn;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Ticket {
	public class DeleteTicketCommand : IRequest<Guid> {

		public Guid Id { get; set; }

		public DeleteTicketCommand(Guid id) {
			Id = id;
		}
		public DeleteTicketCommand() { }
	}
}
