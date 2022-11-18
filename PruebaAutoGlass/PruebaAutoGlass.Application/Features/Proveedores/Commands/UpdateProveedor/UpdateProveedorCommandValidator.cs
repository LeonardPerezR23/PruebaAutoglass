using FluentValidation;

namespace PruebaAutoGlass.Application.Features.Proveedores.Commands.UpdateProveedor
{
    public class UpdateProveedorCommandValidator : AbstractValidator<UpdateProveedorCommand>
    {
        public UpdateProveedorCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotNull().WithMessage("{Nombre} no permite  nulos");

            RuleFor(p => p.Telefono)
            .NotNull().WithMessage("{Telefono} no permite  nulos");

        }
    }
}
