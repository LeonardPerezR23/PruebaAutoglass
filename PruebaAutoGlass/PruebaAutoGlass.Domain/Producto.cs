using PruebaAutoGlass.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAutoGlass.Domain
{
    public class Producto : BaseDomainModel
    {

        public string Nombre { get; set; } = string.Empty;

        public string Estado{ get; set; } = string.Empty;

        public System.DateTime FechaDeFabricacion { get; set; }

        public System.DateTime FechaDeVencimiento { get; set; }



        public int ProveedorId { get; set; }

        public virtual Proveedor? Proveedor { get; set; }
       

    }
}
