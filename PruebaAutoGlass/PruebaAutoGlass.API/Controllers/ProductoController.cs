using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaAutoGlass.Application.Features.Productos.Commands.CreateProducto;
using PruebaAutoGlass.Application.Features.Productos.Commands.DeleteProducto;
using PruebaAutoGlass.Application.Features.Productos.Commands.UpdateProducto;
using PruebaAutoGlass.Application.Features.Productos.Queries.GetProductosList;
using PruebaAutoGlass.Application.Features.Proveedores.Commands.CreateProveedor;
using PruebaAutoGlass.Application.Features.Proveedores.Commands.DeleteProveedor;
using PruebaAutoGlass.Application.Features.Proveedores.Commands.UpdateProveedor;
using System.Net;

namespace PruebaAutoGlass.API.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{username}", Name = "GetProducto")]
        [ProducesResponseType(typeof(IEnumerable<ProductosVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductosVm>>> GetProductosByUsername(string username)
        {
            var query = new GetProductosListQuery(username);
            var productos = await _mediator.Send(query);

            return Ok(productos);
        }
        //_____________________----------------------------------------------------

        [HttpPost(Name = "CreateProducto")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateProducto([FromBody] CreateProductoCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateProducto")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]

        public async Task<ActionResult> UpdateProducto([FromBody] UpdateProductoCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{id}", Name = "DeleteProducto")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]


        public async Task<ActionResult> DeleteProducto(int id)
        {
            var command = new DeleteProductoCommand
            {
                Id = id
            };

            await _mediator.Send(command);

            return NoContent();
        }


    }
}
