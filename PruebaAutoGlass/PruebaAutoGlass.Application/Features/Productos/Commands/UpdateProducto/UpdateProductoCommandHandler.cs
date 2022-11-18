using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PruebaAutoGlass.Application.Contracts.Persistance;
using PruebaAutoGlass.Application.Exceptions;
using PruebaAutoGlass.Domain;

namespace PruebaAutoGlass.Application.Features.Productos.Commands.UpdateProducto
{
    public class UpdateProductoCommandHandler : IRequestHandler<UpdateProductoCommand>
    {

        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateProductoCommandHandler> _logger;

        public UpdateProductoCommandHandler(IProductoRepository productoRepository, IMapper mapper, ILogger<UpdateProductoCommandHandler> logger)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateProductoCommand request, CancellationToken cancellationToken)
        {
            var productoToUpdate = await _productoRepository.GetByIdAsync(request.Id);
            if (productoToUpdate == null)
            {
                _logger.LogError($"No se encontro el id {request.Id} del producto");
                throw new NotFoundException(nameof(Producto), request.Id);

            }

            _mapper.Map(request, productoToUpdate, typeof(UpdateProductoCommand), typeof(Producto));

            await _productoRepository.UpdateAsync(productoToUpdate);

            _logger.LogInformation($"La operacion fue exitosa actualizando el producto {request.Id}");

            return Unit.Value;
        }
    }
}
