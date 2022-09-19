using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static MassTransit.MessageHeaders;

namespace CheckIn.WebApi {
	public class Program {
		public static async Task Main(string[] args) {

			var host = CreateHostBuilder(args).Build();

			using (var scope = host.Services.CreateScope()) {
				IWebHostEnvironment env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

			}

			await host.RunAsync();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
				.UseContentRoot(Directory.GetCurrentDirectory())
				.ConfigureWebHostDefaults(webBuilder => {
					webBuilder.UseStartup<Startup>();
				});
	}
}
