using CheckIn.Application;
using CheckIn.Application.UseCases.Consumers;
using CheckIn.Domain.Repositories;
using CheckIn.Infraestructure.EF;
using CheckIn.Infraestructure.EF.Contexts;
using CheckIn.Infraestructure.EF.Repository;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pedidos.Domain.Repositories;
using ShareKernel.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure {
	public static class Extensions {
		public static IServiceCollection AddInfraestructure(this IServiceCollection services,
			IConfiguration configuration) {

			services.AddAplication();
			services.AddMediatR(Assembly.GetExecutingAssembly());

			var connectionString = configuration.GetConnectionString("AeropuertoDbConnectionString");

			services.AddDbContext<ReadDbContext>(context =>
			context.UseSqlServer(connectionString));
			services.AddDbContext<WriteDbContext>(context =>
			context.UseSqlServer(connectionString));

			services.AddScoped<IVueloRepository, VueloRepository>();
			services.AddScoped<IReservaRepository, ReservaRepository>();
			services.AddScoped<ICheckInRepository, CheckInRepository>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			AddRabbitMq(services, configuration);

			return services;
		}

		private static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration) {
			var rabbitMqHost = configuration["RabbitMq:Host"];
			var rabbitMqPort = configuration["RabbitMq:Port"];
			var rabbitMqUserName = configuration["RabbitMq:UserName"];
			var rabbitMqPassword = configuration["RabbitMq:Password"];

			services.AddMassTransit(config => {

				config.AddConsumer<ReservaCreadoConsumer>().Endpoint(endpoint => endpoint.Name = ReservaCreadoConsumer.QueueName);
				//config.AddConsumer<CheckInCreadoConsumer>().Endpoint(endpoint => endpoint.Name = CheckInCreadoConsumer.QueueName);
				//config.AddConsumer<IntegrationReservaConfirmadaRollbackConsumer>().Endpoint(endpoint => endpoint.Name = IntegrationReservaConfirmadaRollbackConsumer.QueueName);

				config.UsingRabbitMq((context, cfg) => {
					var uri = string.Format("amqp://{0}:{1}@{2}:{3}", rabbitMqUserName, rabbitMqPassword, rabbitMqHost, rabbitMqPort);
					cfg.Host(uri);

					cfg.ReceiveEndpoint(ReservaCreadoConsumer.QueueName, endpoint => {
						endpoint.ConfigureConsumer<ReservaCreadoConsumer>(context);
					});
					//cfg.ReceiveEndpoint(CheckInCreadoConsumer.QueueName, endpoint => {
					//	endpoint.ConfigureConsumer<CheckInCreadoConsumer>(context);
					//});
					//cfg.ReceiveEndpoint(IntegrationReservaConfirmadaRollbackConsumer.QueueName, endpoint => {
					//	endpoint.ConfigureConsumer<IntegrationReservaConfirmadaRollbackConsumer>(context);
					//});
				});
			});
		}

	}
}
