using CheckIn.Application.Dto.Adm;
using CheckIn.Application.Dto.Avion;
using CheckIn.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Avion
{
    public class GetAllAsientoHandler : IRequestHandler<GetAllAsientoQuery, List<AsientoDto>>
    {
        private readonly IAsientoRepository _asientoRepository;
        private readonly ILogger<GetAllAsientoQuery> _logger;

        public GetAllAsientoHandler(IAsientoRepository asientoRepository, ILogger<GetAllAsientoQuery> logger)
        {
            _asientoRepository = asientoRepository;
            _logger = logger;
        }

        public async Task<List<AsientoDto>> Handle(GetAllAsientoQuery request, CancellationToken cancellationToken)
        {
            List<AsientoDto> result = new List<AsientoDto>();
            try
            {
                List<Domain.Model.Avion.Asiento> lista = await _asientoRepository.GellAll();
                foreach (var obj in lista)
                {
                    AsientoDto nuevo = new AsientoDto()
                    {
                        Id = obj.Id,
                        Codigo = obj.Codigo,
                        Fila = obj.Fila,
                        Letra = obj.Letra,
                        EsPrioridad = obj.EsPrioridad,
                    };
                    result.Add(nuevo);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener Todos los Ticket.");
            }
            return result;
        }
    }
}
