using MediatR;

namespace PruebaAutoGlass.Application.Features.Productos.Commands.UpdateProducto
{
    public class UpdateProductoCommand : IRequest
    {

        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;

        public System.DateTime FechaDeFabricacion { get; set; }

        public System.DateTime FechaDeVencimiento { get; set; }

    }
}
