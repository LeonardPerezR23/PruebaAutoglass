using MediatR;

namespace PruebaAutoGlass.Application.Features.Proveedores.Commands.UpdateProveedor
{
    public class UpdateProveedorCommand : IRequest
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;
    }
}
