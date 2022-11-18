using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PruebaAutoGlass.Domain;
using PruebaAutoGlass.Domain.Common;
using System.Data;

namespace PruebaAutoGlass.Infrastructure.Persistence
{
    public class ProveedorDbContext : DbContext
    {

        public ProveedorDbContext(DbContextOptions<ProveedorDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source = DESKTOP-OUBPS3E\TEW_SQLEXPRESS;
        //    Initial Catalog = Producto; Integrated Security = True; TrustServerCertificate=True")
        //  .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
        //  .EnableSensitiveDataLogging();
        //}


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch(entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "system";
                        break;

                        case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "System";
                        break;
                }
            }


                    return base.SaveChangesAsync(cancellationToken);    
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proveedor>()
                .HasMany(m => m.Productos)
                .WithOne(m => m.Proveedor)
                .HasForeignKey(m => m.ProveedorId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductoProveedor>(
           pt => pt.HasKey(e => new { e.ProveedorId, e.ProductoId })
           );


        }


        public DbSet<Proveedor> Proveedores { get; set; }

        public DbSet<Producto> Productos { get; set; }
    }
}
