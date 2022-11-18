using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PruebaAutoGlass.Application.Contracts.Persistance;
using PruebaAutoGlass.Application.Exceptions;
using PruebaAutoGlass.Domain;

namespace PruebaAutoGlass.Application.Features.Productos.Commands.DeleteProducto
{
    public class DeleteProductoCommandHandler : IRequestHandler<DeleteProductoCommand>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteProductoCommandHandler> _logger;

        public DeleteProductoCommandHandler(IProductoRepository productoRepository, IMapper mapper, ILogger<DeleteProductoCommandHandler> logger)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteProductoCommand request, CancellationToken cancellationToken)
        {
            var productoToDelete = await _productoRepository.GetByIdAsync(request.Id);
            if (productoToDelete == null)
            {
                _logger.LogError($"{request.Id} Proveedor no existe en el sistema");
                throw new NotFoundException(nameof(Producto), request.Id);
            }

            await _productoRepository.DeleteAsync(productoToDelete);
            _logger.LogInformation($"El {request.Id} Producto fue eliminado con exito");

            return Unit.Value;
        }
    }
}
