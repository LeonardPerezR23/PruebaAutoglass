using Microsoft.EntityFrameworkCore;
using PruebaAutoGlass.Application.Contracts.Persistance;
using PruebaAutoGlass.Domain;
using PruebaAutoGlass.Infrastructure.Persistence;

namespace PruebaAutoGlass.Infrastructure.Repositories
{
    public class ProductoRepository : RepositoryBase<Producto>, IProductoRepository
    {
        public ProductoRepository(ProveedorDbContext context) : base(context)
        {

        }

        public async Task<Producto> GetProductoByNombre(string nombreProducto)
        {
            return await _context.Productos!.Where(o => o.Nombre == nombreProducto).FirstOrDefaultAsync();


        }

        public async Task<IEnumerable<Producto>> GetProductoByUsername(string username)
        {
            return await _context.Productos!.Where(v => v.CreatedBy == username).ToListAsync();
        }
    }
}
