using CheckIn.Application.Dto.Ticket;
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

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CrearTicketComand command) {
			Guid id = await _mediator.Send(command);
			return Ok(id);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromRoute] GetAllTicketQuery command) {
			List<TicketDto> result = await _mediator.Send(command);
			if (result == null)
				return NotFound();

			return Ok(result);
		}
	}
}
