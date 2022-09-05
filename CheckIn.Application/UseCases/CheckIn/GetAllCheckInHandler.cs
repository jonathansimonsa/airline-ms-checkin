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
	public class GetAllCheckInHandler : IRequestHandler<GetAllCheckInQuery, List<CheckInDto>> {
		private readonly ICheckInRepository _checkInRepository;
		private readonly ILogger<GetAllCheckInHandler> _logger;

		public GetAllCheckInHandler(ICheckInRepository checkInRepository, ILogger<GetAllCheckInHandler> logger) {
			_checkInRepository = checkInRepository;
			_logger = logger;
		}

		public async Task<List<CheckInDto>> Handle(GetAllCheckInQuery request, CancellationToken cancellationToken) {
			List<CheckInDto> result = new List<CheckInDto>();
			try {
				List<Domain.Model.CheckIn.CheckIn> lista = await _checkInRepository.GetAll();
				foreach (var obj in lista) {
					CheckInDto nuevo = new CheckInDto() {
						Id = obj.Id,
						NroCheckIn = obj.NroCheckIn,
						HoraCheckIn = obj.HoraCheckIn,
						EsAltaPrioridad = obj.EsAltaPrioridad,
						LetraAsiento = obj.LetraAsiento,
						NroAsiento = obj.NroAsiento,
						TicketId = obj.TicketId,
						VueloId = obj.VueloId,
						AdministrativoId = obj.AdministrativoId
					};

					foreach (var item in obj.DetalleEquipaje) {
						nuevo.DetalleEquipaje.Add(new EquipajeDto() {
							Id = item.Id,
							Descripcion = item.Descripcion,
							EsFragil = item.EsFragil,
							Peso = item.Peso
						});
					}
					result.Add(nuevo);
				}
			}
			catch (Exception ex) {
				_logger.LogError(ex, "Error al obtener Todos los CheckIn.");
			}
			return result.OrderBy(o => o.NroCheckIn).ToList();
		}

	}
}
