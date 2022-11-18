namespace PruebaAutoGlass.Application.Features.Productos.Queries.GetProductosList
{
    public class ProductosVm
    {
        public string Nombre { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;

        public System.DateTime FechaDeFabricacion { get; set; }

        public System.DateTime FechaDeVencimiento { get; set; }


        public int ProveedorId { get; set; }



    }
}
