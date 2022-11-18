using PruebaAutoGlass.Domain;

namespace PruebaAutoGlass.Application.Contracts.Persistance
{
    public interface IProductoRepository : IAsyncRepository<Producto>
    {
        Task<Producto> GetProductoByNombre(string nombreProducto);

        Task<IEnumerable<Producto>> GetProductoByUsername(string username);

    }
}
