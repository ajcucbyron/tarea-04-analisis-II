using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ddd.ManejoDeTienda.Dominio.Agregados;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infraestructura.SQL.Data
{
    public class AppDbContextSeed
    {        
        public static async Task SeedAsync(AppDbContext context, ILogger<AppDbContextSeed> logger, DateTime testDate, int? retry = 0)
        {
            logger.LogInformation($"Seeding data.");
            logger.LogInformation($"DbContext Type: {context.Database.ProviderName}");

            
            int retryForAvailability = retry.Value;

            try
            {
                if (context.IsRealDatabase())
                {
                    // apply migrations if connecting to a SQL database
                    context.Database.Migrate();
                }

                Guid tiendaId = Guid.Empty;
                if (!await context.Tiendas.AnyAsync())
                {
                    var tienda = CrearTienda();
                    await context.Tiendas.AddAsync(tienda);
                    await context.SaveChangesWithIdentityInsert<Tienda>();
                    tiendaId = tienda.Id;
                }
                
                if (!await context.Productos.AnyAsync())
                {
                    if (tiendaId == Guid.Empty)
                    {
                        var result = await context.Tiendas.FirstAsync();
                        tiendaId = result.Id;
                    }

                    var Productos = CrearProductos(tiendaId);
                    await context.Productos.AddRangeAsync(Productos);
                    await context.SaveChangesWithIdentityInsert<Producto>();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 1)
                {
                    retryForAvailability++;
                    logger.LogError(ex.Message);
                    await SeedAsync(context, logger, testDate, retryForAvailability);
                }
                throw;
            }
        }

        private static Tienda CrearTienda()
        {
            return new Tienda("Acme Inc", "Acme", "101 Grape Avenue", "Suite 100", "USA", "TX", "Dallas");
        }

        private static List<Producto> CrearProductos(Guid tiendaId)
        {
            return new List<Producto>()
            {
                new Producto(tiendaId, "John", "Doe", "555-555-5555", "jdoe@gmail.com", "Producto", new DateTime(1980, 12, 24)),
                new Producto(tiendaId, "Henry", "Smith", "333-555-5555", "hsmith@gmail.com", "Producto", new DateTime(1990, 03, 24))
            };
        }
    }
}
