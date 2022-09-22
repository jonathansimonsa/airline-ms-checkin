using CheckIn.Application.Dto.Reserva;
using CheckIn.Application.Dto.Vuelo;
using CheckIn.Application.UseCases.Reserva;
using CheckIn.Application.UseCases.Vuelo;
using MassTransit;
using MassTransit.Transports;
using MediatR;
using ShareKernel.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Consumers {
	public class ReservaCreadoJsaConsumer : IConsumer<ReservaDto> {

		public const string ExchangeName = "reservaconfirmada-creado-exchange";
		public const string QueueName = "reservaconfirmada-creado-aeropuertojsa";

		public ReservaCreadoJsaConsumer() { }

		public async Task Consume(ConsumeContext<ReservaDto> context) {
			ReservaDto @event = context.Message;
			Console.WriteLine("******** ID = " + @event.Id);
		}
	}
}
