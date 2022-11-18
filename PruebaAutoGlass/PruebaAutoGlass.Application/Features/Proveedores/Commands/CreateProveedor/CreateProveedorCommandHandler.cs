using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PruebaAutoGlass.Application.Contracts.Infrastructure;
using PruebaAutoGlass.Application.Contracts.Persistance;
using PruebaAutoGlass.Application.Models;
using PruebaAutoGlass.Domain;

namespace PruebaAutoGlass.Application.Features.Proveedores.Commands.CreateProveedor
{
    public class CreateProveedorCommandHandler : IRequestHandler<CreateProveedorCommand, int>
    {
        private readonly IProveedorRepository _proveedorRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateProveedorCommandHandler> _logger;

        public CreateProveedorCommandHandler(IProveedorRepository proveedorRepository, IMapper mapper, IEmailService emailService, ILogger<CreateProveedorCommandHandler> logger)
        {
            _proveedorRepository = proveedorRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateProveedorCommand request, CancellationToken cancellationToken)
        {
            var proveedorEntity = _mapper.Map<Proveedor>(request);
            var newProveedor = await _proveedorRepository.AddAsync(proveedorEntity);
            _logger.LogInformation($"El proveedor {newProveedor.Id} fue creado exitosamente");
            await SendEmail(newProveedor);
            return newProveedor.Id;

        }

        private async Task SendEmail(Proveedor proveedor)
        {
            var email = new Email
            {
                To = "leonardunited23@gmail.com",
                Body = "El proveedor se creo correctamente",
                Subject = "Mensaje de alerta"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Errores enviando el email para creacion de {proveedor.Id}");
            }

        }


    }
}
