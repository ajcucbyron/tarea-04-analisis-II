using System.Reflection;
using Ddd.ManejoDeTienda.Dominio.Agregados;
using Ddd.ManejoDeTienda.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.SQL.Data
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<MateriaPrima> MateriasPrimas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<FotoDeServicio> FotosDeServicio { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
