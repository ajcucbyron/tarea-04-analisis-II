using System;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Infraestructura.SQL.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args)
                  .Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var hostEnvironment = services.GetService<IWebHostEnvironment>();
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger<AppDbContextSeed>();
                logger.LogInformation($"Comenzando en ambiente: {hostEnvironment.EnvironmentName}");
                try
                {
                    //var seedService = services.GetRequiredService<AppDbContextSeed>();
                    var dbContext = services.GetRequiredService<AppDbContext>();
                    await AppDbContextSeed.SeedAsync(dbContext,logger, testDate: DateTime.Now, 2);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Ha ocurrido un error en al base de datos.");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
          .UseServiceProviderFactory(new AutofacServiceProviderFactory())
          .ConfigureWebHostDefaults(webBuilder =>
          {
              webBuilder.UseStartup<Startup>();
          });
    }
}
