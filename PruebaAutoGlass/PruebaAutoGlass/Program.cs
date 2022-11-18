
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PruebaAutoGlass.Data;
using PruebaAutoGlass.Domain;
using System;
using System.IO;
using System.Numerics;

ProveedorDbContext dbContext = new();


//await AddNewDatos();
//QueryProvedores();
//await QueryFilter();
//await QueryMethods();
//await QueryLinq();
//await TrackingAndNotTracking();
//await AddNewProveedorWithProducto();
//await AddNewProveedorWithProductoId();
//await AddNewProductoWithProveedor();
await MultipleEntitiesQuery();

Console.WriteLine("Presione cualquier tecla para cerrar");
Console.ReadKey();





async Task MultipleEntitiesQuery()
{
    //var ProductoWithProveedor = await dbContext!.Productos!.Include(q => q.Proveedor).FirstOrDefaultAsync(q => q.Id == 3);

    //var producto = await dbContext!.Productos.Select(q => q.Nombre).ToListAsync();

    var ProductoWithProveedor = await dbContext!.Productos!
                              .Where(q => q.Proveedor != null)
                             .Include(q => q.Proveedor)
                              .Select(q =>
                                new
                               {
                                   Proveedor_completo = $"{q.Proveedor.Nombre} {q.Proveedor.Telefono}",
                                 Prroducto = q.Nombre
                                }
                               )
                              .ToListAsync();

    foreach (var product in ProductoWithProveedor)
   {
        Console.WriteLine($"{product.Prroducto} - {product.Proveedor_completo}");
    }

}






async Task AddNewProductoWithProveedor()
{


    var date1 = new DateTime(2022, 12, 5);
    var date2 = new DateTime(2023, 6, 30);

    if (date1 < date2)
    {

        var producto = new Producto
        {
            Nombre = "Disco",
            Estado = "Activo",
            FechaDeFabricacion = date1,
            FechaDeVencimiento = date2,
                    };

        await dbContext.AddAsync(producto);
        await dbContext.SaveChangesAsync();


        var productoProveedor = new ProductoProveedor
        {
            ProductoId = producto.Id,
            ProveedorId = 1
        };

        await dbContext.AddAsync(productoProveedor);
        await dbContext.SaveChangesAsync();
    }
    else
    {
        Console.WriteLine("La fecha de vencimiento debe ser mayor a la fecha de fabricacion");
    }

}



async Task AddNewProveedorWithProductoId()
{
    var date1 = new DateTime(2022, 1, 1);
    var date2 = new DateTime(2022, 11, 30);

    if (date1 < date2)
    {

        
        var cigueñal = new Producto
        {
            Nombre = "Cigueñal",
            Estado = "Activo",
            FechaDeFabricacion = date1,
            FechaDeVencimiento = date2,
            ProveedorId = 3
        };

        await dbContext.AddAsync(cigueñal);
        await dbContext.SaveChangesAsync();

    }
    else
    {
        Console.WriteLine("La fecha de vencimiento debe ser mayor a la fecha de fabricacion");
    }

}


async Task AddNewProveedorWithProducto()
{
    var date1 = new DateTime(2020, 1, 1);
    var date2 = new DateTime(2023, 1, 1);

    if (date1 < date2)
    {

        var autocol = new Proveedor
        {
            Nombre = "AutoCol",
            Telefono = "601 5864586"
        };

        var rin16 = new Producto
        {
            Nombre = "Rin 16",
            Estado = "Activo",
            FechaDeFabricacion = date1,
            FechaDeVencimiento = date2,

            Proveedor = autocol
        };

        await dbContext.AddAsync(rin16);
        await dbContext.SaveChangesAsync();

    }
    else
    {
        Console.WriteLine("La fecha de vencimiento debe ser mayor a la fecha de fabricacion");
    }
    
}




async Task TrackingAndNotTracking()
{
    var proveedorWithTracking = await dbContext!.Proveedores!.FirstOrDefaultAsync(x => x.Id == 1);
    //var proveedorWithTracking = await dbContext!.Proveedores!.FirstOrDefaultAsync(x => x.Id == 1);

    //var proveedorWithNoTracking = await dbContext!.Proveedores!.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 2);

    proveedorWithTracking.Nombre = "Sofasa";
    //proveedorWithNoTracking.Nombre = "Sofasa";

    await dbContext!.SaveChangesAsync();

}



async Task QueryLinq()
{
    Console.WriteLine($"Ingrese el proveedor");

    var proveedorNombre = Console.ReadLine();
     var proveedores = await (from i in dbContext.Proveedores
                           where EF.Functions.Like(i.Nombre, $"{proveedorNombre}")
                           select i).ToListAsync();


    foreach (var proveedor in proveedores)
    {
        Console.WriteLine($"{proveedor.Id} - {proveedor.Nombre}");
    }

}


async Task QueryFilter()

{
    Console.WriteLine($"Ingrese un proveedor:");
    var proveedorNombre = Console.ReadLine();
    var proveedores = await dbContext!.Proveedores!.Where(x => x.Nombre.Equals(proveedorNombre)).ToListAsync();


    foreach (var proveedor in proveedores)
    {
        Console.WriteLine($"{proveedor.Id} - {proveedor.Nombre}");
    }

    //var streamerPartialResult = await dbContext!.Streamers!.Where(x => x.Nombre.Contains(streamingNombre)).ToListAsync();
    var proveedorPartialResult = await dbContext!.Proveedores!.Where(x => EF.Functions.Like(x.Nombre, $"%{proveedorNombre}%")).ToListAsync();
    foreach (var proveedor in proveedorPartialResult)
    {
        Console.WriteLine($"{proveedor.Id} - {proveedor.Nombre}");
    }
}


async Task QueryMethods()
{
    var proveedor = dbContext!.Proveedores!;

    var firstAsync = await proveedor.Where(y => y.Nombre.Contains("a")).FirstAsync();

    var firstOrDefaultAsync = await proveedor.Where(y => y.Nombre.Contains("a")).FirstOrDefaultAsync();

    var firstOrDefault_v2 = await proveedor.FirstOrDefaultAsync(y => y.Nombre.Contains("a"));

    var singleAsync = await proveedor.Where(y => y.Id == 1).SingleAsync();
    var singleOrDefaultAsync = await proveedor.Where(y => y.Id == 1).SingleOrDefaultAsync();

    var resultado = await proveedor.FindAsync(1);

}


void QueryProvedores()
{
    var proveedores = dbContext!.Proveedores!.ToList();

    foreach (var proveedor in proveedores)
    {
        Console.WriteLine($"{proveedor.Id} - {proveedor.Nombre}");
    }

}


async Task AddNewDatos()
{

    Proveedor proveedor = new()
    {
        Nombre = "Distoyota",
        Telefono = "+57 315 2986452"

    };


    dbContext!.Proveedores!.Add(proveedor);
    await dbContext.SaveChangesAsync();


    var date1 = new DateTime(2023, 3, 1, 7, 0, 0);
    DateTime fechavence = new DateTime(2025, 5, 5);


    var productos = new List<Producto>
{
    new Producto
    {
        Nombre = "Parilla",
        Estado = "Activo",
        FechaDeFabricacion = DateTime.Now,
        ProveedorId = proveedor.Id,

    },

    new Producto
    {
        Nombre = "Radiador",
        Estado = "Activo",
        FechaDeFabricacion = DateTime.Now,
        FechaDeVencimiento = date1,
        ProveedorId = proveedor.Id,

    },


    new Producto
    {
        Nombre = "Alternador",
        Estado = "Activo",
        FechaDeFabricacion = DateTime.Now,
        FechaDeVencimiento = fechavence,
        ProveedorId = proveedor.Id,

    },

     new Producto
    {
        Nombre = "Embrague",
        Estado = "Activo",
        FechaDeFabricacion = DateTime.Now,
        FechaDeVencimiento = DateTime.MaxValue,
        ProveedorId = proveedor.Id,

    },
};


    await dbContext.AddRangeAsync(productos);
    await dbContext.SaveChangesAsync();

}