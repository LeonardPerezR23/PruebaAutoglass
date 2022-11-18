using PruebaAutoGlass.Domain.Common;

namespace PruebaAutoGlass.Domain
{
    public class ProductoProveedor : BaseDomainModel
    {
        public int ProductoId { get; set; }

        public int ProveedorId { get; set; }
    }
}
