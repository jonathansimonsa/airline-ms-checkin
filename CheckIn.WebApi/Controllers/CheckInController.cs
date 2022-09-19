using CheckIn.Application.Dto.CheckIn;
using CheckIn.Application.UseCases.CheckIn;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheckIn.WebApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class CheckInController : ControllerBase {
		private readonly IMediator _mediator;

		public CheckInController(IMediator mediator) {
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromRoute] GetAllCheckInQuery command) {
			List<CheckInDto> result = await _mediator.Send(command);
			if (result == null)
				return NotFound();

			return Ok(result);
		}

		[Route("{id:guid}")]
		[HttpGet]
		public async Task<IActionResult> GetById(Guid id) {
			GetCheckInByIdQuery query = new GetCheckInByIdQuery(id);
			CheckInDto result = await _mediator.Send(query);
			if (result == null)
				return NotFound();

			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateCheckInCommand command) {
			Guid id = await _mediator.Send(command);
			return Ok(id);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(Guid id) {
			DeleteCheckInCommand query = new DeleteCheckInCommand(id);
			Guid result = await _mediator.Send(query);
			return Ok(result);
		}

	}
}
