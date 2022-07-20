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

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CrearCheckInCommand command) {
			Guid id = await _mediator.Send(command);
			return Ok(id);
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
		public async Task<IActionResult> GetById([FromRoute] GetCheckInByIdQuery command) {
			CheckInDto result = await _mediator.Send(command);

			if (result == null)
				return NotFound();

			return Ok(result);
		}

		//[Route("search")]
		//[HttpPost]
		//public async Task<IActionResult> Search([FromBody] SearchPedidosQuery query)
		//{
		//    var pedidos = await _mediator.Send(query);

		//    if (pedidos == null)
		//        return BadRequest();

		//    return Ok(pedidos);
		//}

	}
}
