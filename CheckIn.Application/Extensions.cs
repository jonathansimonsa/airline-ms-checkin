using CheckIn.Application.Services;
using CheckIn.Domain.Factories.Adm;
using CheckIn.Domain.Factories.Avion;
using CheckIn.Domain.Factories.CheckIn;
using CheckIn.Domain.Factories.Ticket;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application {
	public static class Extensions {
		public static IServiceCollection AddAplication(this IServiceCollection services) {
			services.AddMediatR(Assembly.GetExecutingAssembly());
			services.AddTransient<ICheckInService, CheckInService>();
			services.AddTransient<ICheckInFactory, CheckInFactory>();
			services.AddTransient<ITicketFactory, TicketFactory>();
			services.AddTransient<IAsientoFactory, AsientoFactory>();
			services.AddTransient<IAdministrativoFactory, AdministrativoFactory>();

			return services;
		}

	}

}
