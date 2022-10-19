using CheckIn.Application.Dto.Reserva;
using CheckIn.Application.UseCases.ReservaLibre;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheckIn.WebApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class ReservaLibreController : ControllerBase {

		private readonly IMediator _mediator;

		public ReservaLibreController(IMediator mediator) {
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromRoute] GetAllReservaLibreQuery command) {
			List<ReservaDto> result = await _mediator.Send(command);
			if (result == null)
				return NotFound();

			return Ok(result);
		}

	}
}
