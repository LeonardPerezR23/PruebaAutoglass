using FluentValidation;

namespace PruebaAutoGlass.Application.Features.Proveedores.Commands.CreateProveedor
{
    public class CreateProveedorCommandValidator : AbstractValidator<CreateProveedorCommand>
    {
        public CreateProveedorCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{Nombre} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("{Nombre} no puede exceder los 50 caracteres");

            RuleFor(p => p.Telefono)
                .NotEmpty().WithMessage("{Telefono} no puede estar en blanco");
        }
    }
}
