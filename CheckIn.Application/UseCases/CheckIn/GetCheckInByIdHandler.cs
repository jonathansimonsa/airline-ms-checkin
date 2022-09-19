using CheckIn.Application.Dto.CheckIn;
using CheckIn.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.CheckIn {
	public class GetCheckInByIdHandler : IRequestHandler<GetCheckInByIdQuery, CheckInDto> {
		private readonly ICheckInRepository _checkInRepository;
		private readonly ILogger<GetCheckInByIdHandler> _logger;

		public GetCheckInByIdHandler(ICheckInRepository checkInRepository, ILogger<GetCheckInByIdHandler> logger) {
			_checkInRepository = checkInRepository;
			_logger = logger;
		}

		public async Task<CheckInDto> Handle(GetCheckInByIdQuery request, CancellationToken cancellationToken) {
			CheckInDto result = null;
			try {
				Domain.Model.CheckIn.CheckIn obj = await _checkInRepository.FindByIdAsync(request.Id);

				result = new CheckInDto() {
					Id = obj.Id,
					NroCheckIn = obj.NroCheckIn,
					Hora = obj.Hora,
					EsAltaPrioridad = obj.EsAltaPrioridad,
					LetraAsiento = obj.LetraAsiento,
					NroAsiento = obj.NroAsiento,
					ReservaId = obj.ReservaId,
					VueloId = obj.VueloId,
				};

				foreach (var item in obj.DetalleEquipaje) {
					result.DetalleEquipaje.Add(new EquipajeDto() {
						Id = item.Id,
						Descripcion = item.Descripcion,
						EsFragil = item.EsFragil,
						Peso = item.Peso
					});
				}

			}
			catch (Exception ex) {
				_logger.LogError(ex, "Error al obtener CheckIn con id: { CheckInId }", request.Id);
			}
			return result;
		}
	}
}
