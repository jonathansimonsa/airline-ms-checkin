using CheckIn.Application.Dto.Reserva;
using CheckIn.Application.Dto.Vuelo;
using CheckIn.Application.UseCases.Reserva;
using CheckIn.Application.UseCases.Vuelo;
using MassTransit;
using MediatR;
using ShareKernel.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Consumers {
	public class CheckInCreadoConsumer : IConsumer<CheckInCreado> {

		public const string ExchangeName = "checkin-creado-exchange";
		public const string QueueName = "checkin-creado-aeropuertojsa";

		public CheckInCreadoConsumer() { }

		public async Task Consume(ConsumeContext<CheckInCreado> context) {
			CheckInCreado @event = context.Message;
			Console.WriteLine("******** ID = " + @event.Id);

		}
	}
}
