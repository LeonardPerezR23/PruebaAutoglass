using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaAutoGlass.Application.Contracts.Infrastructure;
using PruebaAutoGlass.Application.Contracts.Persistance;
using PruebaAutoGlass.Application.Models;
using PruebaAutoGlass.Infrastructure.Email;
using PruebaAutoGlass.Infrastructure.Persistence;
using PruebaAutoGlass.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAutoGlass.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProveedorDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            );

            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));


            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IProveedorRepository, ProveedorRepository>();



            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;


        }
    }
}
