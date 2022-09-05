using CheckIn.Application.Services;
using CheckIn.Domain.Factories.Adm;
using CheckIn.Domain.Factories.CheckIn;
using CheckIn.Domain.Factories.Ticket;
using CheckIn.Domain.Factories.Vuelo;
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
			services.AddTransient<IAdministrativoFactory, AdministrativoFactory>();
			services.AddTransient<IVueloFactory, VueloFactory>();
			services.AddTransient<ITicketFactory, TicketFactory>();
			services.AddTransient<ICheckInFactory, CheckInFactory>();
			services.AddTransient<ICheckInService, CheckInService>();

			return services;
		}

	}

}
