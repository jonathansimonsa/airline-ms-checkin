using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using CheckIn.Application.UseCases.Vuelo;
using CheckIn.Application.Dto.Vuelo;

namespace CheckIn.WebApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class VueloController : ControllerBase {
		private readonly IMediator _mediator;

		public VueloController(IMediator mediator) {
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromRoute] GetAllVueloQuery command) {
			List<VueloDto> result = await _mediator.Send(command);
			if (result == null)
				return NotFound();

			return Ok(result);
		}

		[Route("{id:guid}")]
		[HttpGet]
		public async Task<IActionResult> GetById(Guid id) {
			GetVueloByIdQuery query = new GetVueloByIdQuery(id);
			VueloDto result = await _mediator.Send(query);
			if (result == null)
				return NotFound();

			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateVueloCommand command) {
			Guid id = await _mediator.Send(command);
			return Ok(id);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(Guid id) {
			DeleteVueloCommand query = new DeleteVueloCommand(id);
			Guid result = await _mediator.Send(query);
			return Ok(result);
		}
	}
}
