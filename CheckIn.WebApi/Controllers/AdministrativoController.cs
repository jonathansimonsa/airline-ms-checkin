using CheckIn.Application.Dto.Adm;
using CheckIn.Application.Dto.CheckIn;
using CheckIn.Application.UseCases.Adm;
using CheckIn.Application.UseCases.CheckIn;
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
	public class AdministrativoController : ControllerBase {
		private readonly IMediator _mediator;

		public AdministrativoController(IMediator mediator) {
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromRoute] GetAllAdmQuery command) {
			List<AdministrativoDto> result = await _mediator.Send(command);
			if (result == null)
				return NotFound();

			return Ok(result);
		}

		[Route("{id:guid}")]
		[HttpGet]
		public async Task<IActionResult> GetById(Guid id) {
			GetAdmByIdQuery query = new GetAdmByIdQuery(id);
			AdministrativoDto result = await _mediator.Send(query);
			if (result == null)
				return NotFound();

			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateAdmCommand command) {
			Guid id = await _mediator.Send(command);
			return Ok(id);
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] CreateAdmCommand command) {
			Guid id = await _mediator.Send(command);
			return Ok(id);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(Guid id) {
			DeleteAdmCommand query = new DeleteAdmCommand(id);
			Guid result = await _mediator.Send(query);
			return Ok(result);
		}

	}
}
