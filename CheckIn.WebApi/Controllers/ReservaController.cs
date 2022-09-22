using CheckIn.Application.Dto.Reserva;
using CheckIn.Application.Dto.Vuelo;
using CheckIn.Application.UseCases.Reserva;
using CheckIn.Application.UseCases.Vuelo;
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
	public class ReservaController : ControllerBase {
		private readonly IMediator _mediator;

		public ReservaController(IMediator mediator) {
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromRoute] GetAllReservaQuery command) {
			List<ReservaDto> result = await _mediator.Send(command);
			if (result == null)
				return NotFound();

			return Ok(result);
		}

		[Route("{id:guid}")]
		[HttpGet]
		public async Task<IActionResult> GetById(Guid id) {
			GetReservaByIdQuery query = new GetReservaByIdQuery(id);
			ReservaDto result = await _mediator.Send(query);
			if (result == null)
				return NotFound();

			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateReservaCommand command) {
			Guid id = await _mediator.Send(command);
			return Ok(id);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(Guid id) {
			DeleteReservaCommand query = new DeleteReservaCommand(id);
			Guid result = await _mediator.Send(query);
			return Ok(result);
		}
	}
}
