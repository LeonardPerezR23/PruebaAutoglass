using MediatR;

namespace PruebaAutoGlass.Application.Features.Proveedores.Commands.DeleteProveedor
{
    public class DeleteProveedorCommand : IRequest
    {
        public int Id { get; set; }

    }
}
