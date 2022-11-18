using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PruebaAutoGlass.Application.Contracts.Persistance;
using PruebaAutoGlass.Application.Exceptions;
using PruebaAutoGlass.Domain;

namespace PruebaAutoGlass.Application.Features.Proveedores.Commands.DeleteProveedor
{
    public class DeleteProveedorCommandHandler : IRequestHandler<DeleteProveedorCommand>
    {
        private readonly IProveedorRepository _proveedorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteProveedorCommandHandler> _logger;

        public DeleteProveedorCommandHandler(IProveedorRepository proveedorRepository, IMapper mapper, ILogger<DeleteProveedorCommandHandler> logger)
        {
            _proveedorRepository = proveedorRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteProveedorCommand request, CancellationToken cancellationToken)
        {
            var proveedorToDelete = await _proveedorRepository.GetByIdAsync(request.Id);
            if (proveedorToDelete == null)
            {
                _logger.LogError($"{request.Id} Proveedor no existe en el sistema");
                throw new NotFoundException(nameof(Proveedor), request.Id);
            }

            await _proveedorRepository.DeleteAsync(proveedorToDelete);
            _logger.LogInformation($"El {request.Id} Proveedor fue eliminado con exito");

            return Unit.Value;
        }
    }
}
