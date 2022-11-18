using PruebaAutoGlass.Application.Contracts.Persistance;
using PruebaAutoGlass.Domain;
using PruebaAutoGlass.Infrastructure.Persistence;

namespace PruebaAutoGlass.Infrastructure.Repositories
{
    public class ProveedorRepository : RepositoryBase<Proveedor>, IProveedorRepository
    {
        public ProveedorRepository(ProveedorDbContext context) : base(context)
        {

        }
    }
}
