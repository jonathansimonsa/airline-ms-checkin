using CheckIn.Application.Services;
using CheckIn.Domain.Factories.CheckIn;
using CheckIn.Domain.Factories.Reserva;
using CheckIn.Domain.Factories.Vuelo;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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

			services.AddSingleton<IVueloFactory, VueloFactory>();
			services.AddSingleton<IReservaFactory, ReservaFactory>();
			services.AddTransient<ICheckInService, CheckInService>();
			services.AddTransient<ICheckInFactory, CheckInFactory>();

			return services;
		}

	}

}
