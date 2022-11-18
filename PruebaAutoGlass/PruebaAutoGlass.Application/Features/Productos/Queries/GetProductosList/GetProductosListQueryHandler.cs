using AutoMapper;
using MediatR;
using PruebaAutoGlass.Application.Contracts.Persistance;

namespace PruebaAutoGlass.Application.Features.Productos.Queries.GetProductosList
{
    public class GetProductosListQueryHandler : IRequestHandler<GetProductosListQuery, List<ProductosVm>>
    {
        private readonly IProductoRepository _productoRespository;
        private readonly IMapper _mapper;

        public GetProductosListQueryHandler(IProductoRepository productoRespository, IMapper mapper)
        {
            _productoRespository = productoRespository;
            _mapper = mapper;
        }


        public async Task<List<ProductosVm>> Handle(GetProductosListQuery request, CancellationToken cancellationToken)
        {
            var productoList = await _productoRespository.GetProductoByUsername(request._Username);



            return _mapper.Map<List<ProductosVm>>(productoList);
        }



    }
}
