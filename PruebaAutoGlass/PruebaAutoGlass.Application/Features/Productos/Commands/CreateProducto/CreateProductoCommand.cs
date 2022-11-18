using MediatR;

namespace PruebaAutoGlass.Application.Features.Productos.Commands.CreateProducto
{
    public class CreateProductoCommand : IRequest<int>
    {
        public string Nombre { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;

        public DateTime FechaDeFabricacion { get; set; }

        public DateTime FechaDeVencimiento { get; set; }


    }
}
