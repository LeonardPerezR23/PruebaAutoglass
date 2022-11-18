using MediatR;

namespace PruebaAutoGlass.Application.Features.Productos.Queries.GetProductosList
{
    public class GetProductosListQuery : IRequest<List<ProductosVm>>
    {
        public string _Username { get; set; } = string.Empty;

        public GetProductosListQuery(string username)
        {
            _Username = username ?? throw new ArgumentNullException(nameof(username));
        }
    }
}
