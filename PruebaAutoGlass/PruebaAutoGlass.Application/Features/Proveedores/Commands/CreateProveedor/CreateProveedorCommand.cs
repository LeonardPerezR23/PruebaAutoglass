using MediatR;

namespace PruebaAutoGlass.Application.Features.Proveedores.Commands.CreateProveedor
{
    public class CreateProveedorCommand : IRequest<int>
    {
        public string? Nombre { get; set; } = string.Empty;

        public string? Telefono { get; set; } = string.Empty;



    }
}
