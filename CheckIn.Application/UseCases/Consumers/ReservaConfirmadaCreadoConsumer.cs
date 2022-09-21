using CheckIn.Application.Dto.Reserva;
using CheckIn.Application.Dto.Vuelo;
using CheckIn.Application.UseCases.Reserva;
using CheckIn.Application.UseCases.Vuelo;
using MassTransit;
using MassTransit.Transports;
using MediatR;
using Microsoft.Extensions.Logging;
using ShareKernel.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Consumers {
	public class ReservaConfirmadaCreadoConsumer : IConsumer<ReservaCreado> {

		private readonly IMediator _mediator;
		public const string ExchangeName = "reserva.reservaconfirmada.exchange";
		public const string QueueName = "reserva.reservaconfirmada.checkin.crearcheckin";

		private readonly IPublishEndpoint _publishEndpoint;

		public ReservaConfirmadaCreadoConsumer(IMediator mediator, IPublishEndpoint publishEndpoint) {
			_mediator = mediator;
			_publishEndpoint = publishEndpoint;
		}

		public async Task Consume(ConsumeContext<ReservaCreado> context) {
			ReservaCreado @event = context.Message;
			try {
				GetVueloByIdQuery query_V = new GetVueloByIdQuery(new Guid(@event.vueloId));
				VueloDto result_V = await _mediator.Send(query_V);

				if (result_V == null) {
					//	CREAR VUELO SINO EXISTE
					CreateVueloCommand command_Vuelo = new CreateVueloCommand(new Guid(@event.vueloId), @event.origen, @event.destino);
					Guid result_vueloId = await _mediator.Send(command_Vuelo);

					if (result_vueloId.Equals(Guid.Empty)) throw new Exception();
				}

				GetReservaByIdQuery query_R = new GetReservaByIdQuery(new Guid(@event.reservaId));
				ReservaDto result_R = await _mediator.Send(query_R);

				if (result_R == null) {
					// CREAR RESERVA SINO EXISTE
					CreateReservaCommand command_Reserva = new CreateReservaCommand(
						new Guid(@event.reservaId),
						DateTime.Parse(@event.hora),
						new Guid(@event.vueloId),
						new Guid(@event.pagoId));
					Guid result_ReservaId = await _mediator.Send(command_Reserva);

					if (result_ReservaId.Equals(Guid.Empty)) throw new Exception();

					query_R = new GetReservaByIdQuery(result_ReservaId);
					result_R = await _mediator.Send(query_R);
				}

				await _publishEndpoint.Publish(result_R);
			}
			catch (Exception) {
				IntegrationReservaConfirmadaRollback evento = new IntegrationReservaConfirmadaRollback(@event.reservaId, @event.pagoId);
				await _publishEndpoint.Publish(evento);
			}

		}
	}
}
