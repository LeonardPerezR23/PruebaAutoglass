using FluentValidation;

namespace PruebaAutoGlass.Application.Features.Productos.Commands.UpdateProducto
{
    public class UpdateProductoCommandValidator : AbstractValidator<UpdateProductoCommand>
    {
        public UpdateProductoCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{Nombre} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("{Nombre} no puede exceder los 50 caracteres");

            RuleFor(p => p.Estado)
              .NotEmpty().WithMessage("{Estado} no puede estar en blanco")
              .NotNull()
              .MaximumLength(10).WithMessage("{Estado} no puede exceder los 10 caracteres");

            RuleFor(p => p.FechaDeFabricacion)
                .NotEmpty().WithMessage("{FechaDeFabricacion} no puede estar en blanco");


            RuleFor(p => p.FechaDeVencimiento)
                .LessThanOrEqualTo(p => p.FechaDeFabricacion).WithMessage("{FechaDeVencimiento} no puede ser menor o igual que {FechaDeFabricacion}")
                .NotEmpty().WithMessage("{FechaDeVencimiento} no puede estar en blanco");

        }
    }
}
