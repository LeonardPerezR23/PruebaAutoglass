using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PruebaAutoGlass.Application.Contracts.Persistance;
using PruebaAutoGlass.Application.Exceptions;
using PruebaAutoGlass.Domain;

namespace PruebaAutoGlass.Application.Features.Proveedores.Commands.UpdateProveedor
{
    public class UpdateProveedorCommandHandler : IRequestHandler<UpdateProveedorCommand>
    {
        private readonly IProveedorRepository _proveedorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateProveedorCommandHandler> _logger;

        public UpdateProveedorCommandHandler(IProveedorRepository proveedorRepository, IMapper mapper, ILogger<UpdateProveedorCommandHandler> logger)
        {
            _proveedorRepository = proveedorRepository;
            _mapper = mapper;
            _logger = logger;
        }
         
        public async Task<Unit> Handle(UpdateProveedorCommand request, CancellationToken cancellationToken)
        {
            var proveedorToUpdate = await _proveedorRepository.GetByIdAsync(request.Id);
            if (proveedorToUpdate == null)
            {


                _logger.LogError($"No se encontro el id {request.Id} del proveedor");
                throw new NotFoundException(nameof(Proveedor), request.Id);
            }

            _mapper.Map(request, proveedorToUpdate, typeof(UpdateProveedorCommand), typeof(Proveedor));

            await _proveedorRepository.UpdateAsync(proveedorToUpdate);

            _logger.LogInformation($"La operacion fue exitosa actualizando el proveedor {request.Id}");

            return Unit.Value;
        }
    }
}
