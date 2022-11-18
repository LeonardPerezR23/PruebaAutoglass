using Microsoft.Extensions.Logging;
using PruebaAutoGlass.Domain;

namespace PruebaAutoGlass.Infrastructure.Persistence
{
    public class ProveedorDbContextSeed
    {
        public static async Task SeedAsync(ProveedorDbContext context, ILogger<ProveedorDbContextSeed> logger)
        {
            if (!context.Proveedores!.Any())
            {
                context.Proveedores!.AddRange(GetPreconfiguredProveedor());
                await context.SaveChangesAsync();
                logger.LogInformation("Se estan insertando nuevos datos a la base de datos{context}", typeof(ProveedorDbContext).Name);
            }
        }
        private static IEnumerable<Proveedor> GetPreconfiguredProveedor()
        {
            return new List<Proveedor>
            {
                new Proveedor { CreatedBy= "Leonardo", Nombre = "AutoTunnig", Telefono = "+55 6864152652"},
                new Proveedor { CreatedBy= "Leonardo", Nombre = "Floresta", Telefono = "+57 601 54862545"},
            };
        }

    }
}
