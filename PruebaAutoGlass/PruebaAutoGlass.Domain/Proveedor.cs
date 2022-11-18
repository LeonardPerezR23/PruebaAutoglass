using PruebaAutoGlass.Domain.Common;

namespace PruebaAutoGlass.Domain
{
    public class Proveedor : BaseDomainModel
    {
       
        public string? Nombre { get; set; } 

        public string? Telefono { get; set; }

        //public virtual Producto Producto { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }  
    }
}
