using AutoMapper;
using PruebaAutoGlass.Application.Features.Productos.Commands.CreateProducto;
using PruebaAutoGlass.Application.Features.Productos.Queries.GetProductosList;
using PruebaAutoGlass.Application.Features.Proveedores.Commands.CreateProveedor;
using PruebaAutoGlass.Domain;

namespace PruebaAutoGlass.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Producto, ProductosVm>();

            CreateMap<CreateProveedorCommand, Proveedor>();

            CreateMap<CreateProductoCommand, Producto>();
        }
    }
}
