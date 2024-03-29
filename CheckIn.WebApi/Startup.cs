using CheckIn.Application;
using CheckIn.Infraestructure;
using CheckIn.Infraestructure.EF.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckIn.WebApi {
	public class Startup {

		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {

			services.AddCors(option =>
				option.AddDefaultPolicy(builder =>
					builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
				)
			);

			services.AddInfraestructure(Configuration);

			services.AddControllers();

			services.AddSwaggerGen(c => {
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "CheckIn.WebApi", Version = "v1" });
			});

			services.AddDbContext<ReadDbContext>(options =>
			   options.UseSqlServer(Configuration.GetConnectionString("AeropuertoDbConnectionString")));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {

			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CheckIn.WebApi v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();
			app.UseCors();

			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});

			using (var serviceScope = app.ApplicationServices.CreateScope()) {
				var context = serviceScope.ServiceProvider.GetService<ReadDbContext>();
				context.Database.Migrate();
			}
		}
	}
}
