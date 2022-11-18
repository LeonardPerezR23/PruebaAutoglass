using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PruebaAutoGlass.Application.Contracts.Infrastructure;
using PruebaAutoGlass.Application.Contracts.Persistance;
using PruebaAutoGlass.Application.Models;
using PruebaAutoGlass.Domain;

namespace PruebaAutoGlass.Application.Features.Productos.Commands.CreateProducto
{
    public class CreateProductoCommandHandler : IRequestHandler<CreateProductoCommand, int>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateProductoCommandHandler> _logger;

        public CreateProductoCommandHandler(IProductoRepository productoRepository, IMapper mapper, IEmailService emailService, ILogger<CreateProductoCommandHandler> logger)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateProductoCommand request, CancellationToken cancellationToken)
        {

            var productoEntity = _mapper.Map<Producto>(request);
            var newProducto = await _productoRepository.AddAsync(productoEntity);
            _logger.LogInformation($"El proveedor {newProducto.Id} fue creado exitosamente");
            await SendEmail(newProducto);
            return newProducto.Id;

        }

        private async Task SendEmail(Producto producto)
        {
            var email = new Email
            {
                To = "leonardunited23@gmail.com",
                Body = "El producto se creo correctamente",
                Subject = "Mensaje de alerta"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Errores enviando el email para creacion de {producto.Id}");
            }

        }



    }
}
