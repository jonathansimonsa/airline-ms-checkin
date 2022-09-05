using CheckIn.Application.Dto.Adm;
using CheckIn.Application.Dto.CheckIn;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Adm {
	public class DeleteAdmCommand : IRequest<Guid> {

		public Guid Id { get; set; }

		public DeleteAdmCommand(Guid id) {
			Id = id;
		}
		public DeleteAdmCommand() { }
	}
}
