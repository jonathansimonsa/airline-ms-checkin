using CheckIn.Application.Dto.Ticket;
using CheckIn.Application.UseCases.Adm;
using CheckIn.Application.UseCases.Ticket;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckIn.WebApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class TicketController : ControllerBase {
		private readonly IMediator _mediator;

		public TicketController(IMediator mediator) {
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromRoute] GetAllTicketQuery command) {
			List<TicketDto> result = await _mediator.Send(command);
			if (result == null)
				return NotFound();

			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateTicketCommand command) {
			Guid id = await _mediator.Send(command);
			return Ok(id);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(Guid id) {
			DeleteTicketCommand query = new DeleteTicketCommand(id);
			Guid result = await _mediator.Send(query);
			return Ok(result);
		}
	}
}
