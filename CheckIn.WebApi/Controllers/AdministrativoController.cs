using CheckIn.Application.Dto.Adm;
using CheckIn.Application.UseCases.Adm;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckIn.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdministrativoController : ControllerBase
	{
		private readonly IMediator _mediator;

		public AdministrativoController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CrearAdmCommand command)
		{
			Guid id = await _mediator.Send(command);
			return Ok(id);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromRoute] GetAllAdmQuery command)
		{
			List<AdministrativoDto> result = await _mediator.Send(command);
			if (result == null)
				return NotFound();

			return Ok(result);
		}

		/* [Route("{id:guid}")]
		 [HttpGet]
		 public async Task<IActionResult> GetById([FromRoute] GetCheckInByIdQuery command)
		 {
			CheckInDto result = await _mediator.Send(command);

			if (result == null)
			    return NotFound();

			return Ok(result);
		 }*/
	}
}
