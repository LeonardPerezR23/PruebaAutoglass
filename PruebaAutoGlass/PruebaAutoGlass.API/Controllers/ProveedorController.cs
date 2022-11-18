using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaAutoGlass.Application.Features.Proveedores.Commands.CreateProveedor;
using PruebaAutoGlass.Application.Features.Proveedores.Commands.DeleteProveedor;
using PruebaAutoGlass.Application.Features.Proveedores.Commands.UpdateProveedor;
using System.Net;

namespace PruebaAutoGlass.API.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProveedorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProveedorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateProveedor")]
        [ProducesResponseType((int)HttpStatusCode.OK)]

        public async Task<ActionResult<int>> CreateProveedor([FromBody]CreateProveedorCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateProveedor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]

        public async Task<ActionResult> UpdateProveedor([FromBody] UpdateProveedorCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteProveedor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]

        public async Task<ActionResult> DeleteProveedor(int id)
        {
            var command = new DeleteProveedorCommand
            {
                Id = id
            };

           await _mediator.Send(command);

            return NoContent();
        }

    }
}
