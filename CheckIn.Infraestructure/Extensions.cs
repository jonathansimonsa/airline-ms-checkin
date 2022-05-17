using CheckIn.Application;
using CheckIn.Domain.Repositories;
using CheckIn.Infraestructure.EF;
using CheckIn.Infraestructure.EF.Contexts;
using CheckIn.Infraestructure.EF.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pedidos.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAplication();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            var connectionString = configuration.GetConnectionString("AeropuertoDbConnectionString");

            services.AddDbContext<ReadDbContext>(context =>
            context.UseSqlServer(connectionString));
            services.AddDbContext<WriteDbContext>(context =>
            context.UseSqlServer(connectionString));

            services.AddScoped<ICheckInRepository, CheckInRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

    }
}
