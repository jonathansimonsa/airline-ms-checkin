using CheckIn.Application.Services;
using CheckIn.Domain.Factories.CheckIn;
using CheckIn.Domain.Factories.Reserva;
using CheckIn.Domain.Factories.Vuelo;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application {
	[ExcludeFromCodeCoverage]
	public static class Extensions {
		public static IServiceCollection AddAplication(this IServiceCollection services) {

			services.AddMediatR(Assembly.GetExecutingAssembly());

			services.AddTransient<IVueloFactory, VueloFactory>();
			services.AddTransient<IReservaFactory, ReservaFactory>();
			services.AddSingleton<ICheckInService, CheckInService>();
			services.AddSingleton<ICheckInFactory, CheckInFactory>();

			return services;
		}

	}

}
