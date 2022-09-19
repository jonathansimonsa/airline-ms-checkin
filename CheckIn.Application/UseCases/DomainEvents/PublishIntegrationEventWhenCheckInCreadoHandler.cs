using CheckIn.Domain.Event;
using MassTransit;
using MediatR;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CheckIn.Application.UseCases.DomainEvents {
	public class PublishIntegrationEventWhenCheckInCreadoHandler : INotificationHandler<ConfirmedDoaminEvent<CheckInCreado>> {

		private readonly IPublishEndpoint _publishEndpoint;

		public PublishIntegrationEventWhenCheckInCreadoHandler(IPublishEndpoint publishEndpoint) {
			_publishEndpoint = publishEndpoint;
		}

		public async Task Handle(ConfirmedDoaminEvent<CheckInCreado> notification, CancellationToken cancellationToken) {
			ShareKernel.IntegrationEvents.CheckInCreado evento = new ShareKernel.IntegrationEvents.CheckInCreado() {
				Id = notification.DomainEvent.Id,
				NroCheckIn = notification.DomainEvent.NroCheckIn,
				Hora = notification.DomainEvent.Hora,
				EsAltaPrioridad = notification.DomainEvent.EsAltaPrioridad,
				LetraAsiento = notification.DomainEvent.LetraAsiento,
				NroAsiento = notification.DomainEvent.NroAsiento,
				ReservaId = notification.DomainEvent.ReservaId,
				VueloId = notification.DomainEvent.VueloId,
			};
			await _publishEndpoint.Publish<ShareKernel.IntegrationEvents.CheckInCreado>(evento);
		}
	}
}
