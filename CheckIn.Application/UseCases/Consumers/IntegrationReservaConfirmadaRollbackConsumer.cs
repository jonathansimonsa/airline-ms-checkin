using MassTransit;
using MediatR;
using ShareKernel.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.Consumers {
	[ExcludeFromCodeCoverage]
	public class IntegrationReservaConfirmadaRollbackConsumer : IConsumer<IntegrationReservaConfirmadaRollback> {

		public const string ExchangeName = "IntegrationReservaConfirmadaRollback-creado-exchange";
		public const string QueueName = "IntegrationReservaConfirmadaRollback-creado-aeropuertojsa";

		public IntegrationReservaConfirmadaRollbackConsumer() { }

		public async Task Consume(ConsumeContext<IntegrationReservaConfirmadaRollback> context) {
			IntegrationReservaConfirmadaRollback @event = context.Message;
			Console.WriteLine("******** ID = " + @event.reservaId);

		}
	}
}
