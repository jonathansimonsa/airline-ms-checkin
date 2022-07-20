using CheckIn.Application.Dto.Avion;
using CheckIn.Application.UseCases.Avion;
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
	public class AsientoController : ControllerBase {
		private readonly IMediator _mediator;

		public AsientoController(IMediator mediator) {
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CrearAsientoComand command) {
			Guid id = await _mediator.Send(command);
			return Ok(id);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromRoute] GetAllAsientoQuery command) {
			List<AsientoDto> result = await _mediator.Send(command);
			if (result == null)
				return NotFound();

			return Ok(result);
		}

	}
}
