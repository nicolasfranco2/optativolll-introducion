using optativolll_introducion.services.Logica;
using optativolll_introducion.services;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.CompilerServices;
using optativolll_introducion.repositorios.Cliente;
using optativolll_introducion.repositorios.Factura;
using optativolll_introducion.repositorios.Sucursal;
using Optativolll_Introduccion.Repositorios.Productos;

string connectionString = "Host=localhost;port=5432;Database=optativo;Username=postgres;Password=steamat10;";

ClienteServices clienteservices = new ClienteServices(connectionString);
FacturaServices facturaservices = new FacturaServices(connectionString);
SucursalServices sucursalservices = new SucursalServices(connectionString);
ProductoServices productoservices = new ProductoServices(connectionString);
DetalleFacturaServices detalleFacturaServices = new DetalleFacturaServices(connectionString);

Console.WriteLine(" ingrese: \n a - para insertar cliente nuevo  \n b - para listar clientes \n c - para Actualizar clientes " +
    " \n d - para Eliminar clientes \n e - para Insertar Factura nueva \n f - para listar Facturas " +
    "\n g - para Actualizar Facturas \n h - para Eliminar Facturas  \n i - Para insertar una sucursal \n j - para listar sucursal " +
    "\n k - para actualizar la sucursal \n l - para eliminar la sucursal");
  string opcion = Console.ReadLine();

if (opcion == "a")
    {
    Console.WriteLine("Ingrese el nombre del cliente:");
    string nombre = Console.ReadLine();

    Console.WriteLine("Ingrese el apellido del cliente:");
    string apellido = Console.ReadLine();

    Console.WriteLine("Ingrese el documento del cliente:");
    string documento = Console.ReadLine();

    Console.WriteLine("Ingrese el correo electrónico del cliente:");
    string mail = Console.ReadLine();

    Console.WriteLine("Ingrese su direccion:");
    string direcicion = Console.ReadLine();

    Console.WriteLine("Ingrese el número de celular del cliente:");
    string celular = Console.ReadLine();

    Console.WriteLine("Ingrese el estado del cliente:");
    string estado = Console.ReadLine();

    clienteservices.Insertar(new Cliente
    {
        Nombre = nombre,
        Apellido = apellido,
        Documento = documento,
        Mail = mail,
        Direccion = direcicion,
        Celular = celular,
        Estado = estado
    }) ;
        
     
}
if (opcion == "b")
{

    clienteservices.GetAll().ToList().ForEach(cliente =>

    Console.WriteLine(
        $"Nombre: {cliente.Nombre} \n" +
        $"Apellido: {cliente.Apellido} \n" +
        $"Documento: {cliente.Documento} \n" +
        $"Mail: {cliente.Mail} \n" +
        $"Direccion: {cliente.Direccion} \n" +
        $"Celular: {cliente.Celular} \n" +
        $"Estado: {cliente.Estado} \n"
        )
    );
    
}

else if (opcion == "c")

    clienteservices.GetAll().ToList().ForEach(cliente =>

   Console.WriteLine(
       $"ID: {cliente.Id} \n" +
       $"Nombre: {cliente.Nombre} \n" +
       $"Apellido: {cliente.Apellido} \n" +
       $"Documento: {cliente.Documento} \n" +
       $"Mail: {cliente.Mail} \n" +
       $"Direccion: {cliente.Direccion} \n" +
       $"Celular: {cliente.Celular} \n" +
       $"Estado: {cliente.Estado} \n"
       )
   );


{
    Console.WriteLine("Ingrese el ID del cliente que desea actualizar:");
    if (!int.TryParse(Console.ReadLine(), out int idCliente))
    {
        Console.WriteLine("Formato de ID inválido. Intente nuevamente.");
        return;
    }

    try
    {
        // Obtener el cliente por su ID
        Cliente clienteExistente = clienteservices.GetClienteById(idCliente);

        if (clienteExistente == null)
        {
            Console.WriteLine($"No se puede actualizar el cliente con ID {idCliente} porque no existe en la base de datos.");
            return;
        }

        // Obtener los datos actualizados del cliente
        Console.WriteLine("Ingrese el nombre del cliente:");
        clienteExistente.Nombre = Console.ReadLine();

        Console.WriteLine("Ingrese el apellido del cliente:");
        clienteExistente.Apellido = Console.ReadLine();

        Console.WriteLine("Ingrese el documento del cliente:");
        clienteExistente.Documento = Console.ReadLine();

        Console.WriteLine("Ingrese el correo electrónico del cliente:");
        clienteExistente.Mail = Console.ReadLine();

        Console.WriteLine("Ingrese su dirección:");
        clienteExistente.Direccion = Console.ReadLine();

        Console.WriteLine("Ingrese el número de celular del cliente:");
        clienteExistente.Celular = Console.ReadLine();

        Console.WriteLine("Ingrese el estado del cliente:");
        clienteExistente.Estado = Console.ReadLine();

        // Llamar al método para actualizar el cliente en la base de datos
        bool actualizado = clienteservices.Update(clienteExistente);

        if (actualizado)
        {
            Console.WriteLine("Cliente actualizado exitosamente.");
        }
        else
        {
            Console.WriteLine("No se pudo actualizar el cliente.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al intentar actualizar el cliente: {ex.Message}");
    }
}
if (opcion == "d")
{
    Console.WriteLine("Ingrese el ID del cliente que desea eliminar:");
    int idCliente;
    if (!int.TryParse(Console.ReadLine(), out idCliente))
    {
        Console.WriteLine("Formato de ID inválido. Intente nuevamente.");
        return; // Termina la ejecución del programa
    }

    try
    {
        clienteservices.EliminarCliente(idCliente);
        Console.WriteLine("Cliente eliminado exitosamente.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al intentar eliminar el cliente: {ex.Message}");
    }



    if (opcion == "e")
    {
        Console.WriteLine("Ingrese el número de factura:");
        string nroFactura = Console.ReadLine();

        Console.WriteLine("Ingrese la fecha y hora de la factura (en formato yyyy-MM-dd HH:mm:ss):");
        DateTime fechaHora;
        if (!DateTime.TryParse(Console.ReadLine(), out fechaHora))
        {
            Console.WriteLine("Formato de fecha y hora inválido. Intente nuevamente.");
            return; // Termina la ejecución del programa
        }

        Console.WriteLine("Ingrese el total de la factura:");
        decimal total;
        if (!decimal.TryParse(Console.ReadLine(), out total))
        {
            Console.WriteLine("Formato de total inválido. Intente nuevamente.");
            return; // Termina la ejecución del programa
        }

        Console.WriteLine("Ingrese el total de IVA al 5%:");
        decimal totalIva5;
        if (!decimal.TryParse(Console.ReadLine(), out totalIva5))
        {
            Console.WriteLine("Formato de total de IVA al 5% inválido. Intente nuevamente.");
            return; // Termina la ejecución del programa
        }

        Console.WriteLine("Ingrese el total de IVA al 10%:");
        decimal totalIva10;
        if (!decimal.TryParse(Console.ReadLine(), out totalIva10))
        {
            Console.WriteLine("Formato de total de IVA al 10% inválido. Intente nuevamente.");
            return; // Termina la ejecución del programa
        }

        Console.WriteLine("Ingrese el total de IVA:");
        decimal totalIva;
        if (!decimal.TryParse(Console.ReadLine(), out totalIva))
        {
            Console.WriteLine("Formato de total de IVA inválido. Intente nuevamente.");
            return; // Termina la ejecución del programa
        }

        Console.WriteLine("Ingrese el total en letras:");
        string totalLetras = Console.ReadLine();

        Console.WriteLine("Ingrese la sucursal:");
        string sucursal = Console.ReadLine();

        facturaservices.Insertar_Factura(new Factura

        {
            NroFactura = nroFactura,
            FechaHora = fechaHora,
            Total = total,
            TotalIva5 = totalIva5,
            TotalIva10 = totalIva10,
            TotalIva = totalIva,
            TotalLetras = totalLetras,
            Sucursal = sucursal


        });
    }
    if (opcion == "f")
    {

        facturaservices.listado().ForEach(Factura =>
            Console.WriteLine(
            $"Nro. Factura: {Factura.NroFactura} \n" +
            $"Fecha y Hora: {Factura.FechaHora} \n" +
            $"Total: {Factura.Total} \n" +
            $"Total IVA al 5%: {Factura.TotalIva5} \n" +
            $"Total IVA al 10%: {Factura.TotalIva10} \n" +
            $"Total IVA: {Factura.TotalIva} \n" +
            $"Total en Letras: {Factura.TotalLetras} \n" +
            $"Sucursal: {Factura.Sucursal} \n"

        ));
    }
    if (opcion == "g")
    {
        Console.WriteLine("Ingrese el ID de la factura que desea actualizar:");
        if (!int.TryParse(Console.ReadLine(), out int idFactura))
        {
            Console.WriteLine("Formato de ID inválido. Intente nuevamente.");
            return;
        }

        try
        {
            // Obtener la factura por su ID
            Factura facturaExistente = facturaservices.GetFacturaById(idFactura);

            if (facturaExistente == null)
            {
                Console.WriteLine($"No se puede actualizar la factura con ID {idFactura} porque no existe en la base de datos.");
                return;
            }

            // Obtener los datos actualizados de la factura
            Console.WriteLine("Ingrese el número de factura:");
            string nroFactura = Console.ReadLine();

            Console.WriteLine("Ingrese la fecha y hora de la factura (en formato yyyy-MM-dd HH:mm:ss):");
            DateTime fechaHora;
            if (!DateTime.TryParse(Console.ReadLine(), out fechaHora))
            {
                Console.WriteLine("Formato de fecha y hora inválido. Intente nuevamente.");
                return;
            }

            Console.WriteLine("Ingrese el total de la factura:");
            decimal total;
            if (!decimal.TryParse(Console.ReadLine(), out total))
            {
                Console.WriteLine("Formato de total inválido. Intente nuevamente.");
                return;
            }

            Console.WriteLine("Ingrese el total de IVA al 5%:");
            decimal totalIva5;
            if (!decimal.TryParse(Console.ReadLine(), out totalIva5))
            {
                Console.WriteLine("Formato de total de IVA al 5% inválido. Intente nuevamente.");
                return;
            }

            Console.WriteLine("Ingrese el total de IVA al 10%:");
            decimal totalIva10;
            if (!decimal.TryParse(Console.ReadLine(), out totalIva10))
            {
                Console.WriteLine("Formato de total de IVA al 10% inválido. Intente nuevamente.");
                return;
            }

            Console.WriteLine("Ingrese el total de IVA:");
            decimal totalIva;
            if (!decimal.TryParse(Console.ReadLine(), out totalIva))
            {
                Console.WriteLine("Formato de total de IVA inválido. Intente nuevamente.");
                return;
            }

            Console.WriteLine("Ingrese el total en letras:");
            string totalLetras = Console.ReadLine();

            Console.WriteLine("Ingrese la sucursal:");
            string sucursal = Console.ReadLine();

            // Actualizar la factura con los nuevos datos
            facturaExistente.NroFactura = nroFactura;
            facturaExistente.FechaHora = fechaHora;
            facturaExistente.Total = total;
            facturaExistente.TotalIva5 = totalIva5;
            facturaExistente.TotalIva10 = totalIva10;
            facturaExistente.TotalIva = totalIva;
            facturaExistente.TotalLetras = totalLetras;
            facturaExistente.Sucursal = sucursal;

            // Llamar al método para actualizar la factura en la base de datos
            bool actualizado = facturaservices.ActualizarFactura(facturaExistente);

            if (actualizado)
            {
                Console.WriteLine("Factura actualizada exitosamente.");
            }
            else
            {
                Console.WriteLine("No se pudo actualizar la factura.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al intentar actualizar la factura: {ex.Message}");
        }
    }
    else
    {
        Console.WriteLine("Opción no válida.");
    }

    if (opcion == "h")
    {
        Console.WriteLine("Ingrese el nombre de la sucursal:");
        string descripcion = Console.ReadLine();

        Console.WriteLine("Ingrese la direccion de la sucursal:");
        string direccion = Console.ReadLine();

        Console.WriteLine("El telefono de la sucursal:");
        string telefono = Console.ReadLine();

        Console.WriteLine("Ingrese el whatsapp de la sucursal:");
        string whatsapp = Console.ReadLine();

        Console.WriteLine("Ingrese su direccion de correo electronico:");
        string mail = Console.ReadLine();

        Console.WriteLine("ingrese el estado de la sucursal");
        string estado = Console.ReadLine();


        sucursalservices.Insertar(new Sucursal

        {
            descripcion = descripcion,
            direccion = direccion,
            telefono = telefono,
            whatsapp = whatsapp,
            mail = mail,
            estado = estado
           
        });


    }

    private static void InsertarProducto(ProductoServices productoservices)
    {
        Console.WriteLine("Ingrese el nombre del producto:");
        string nombre = Console.ReadLine();

        Console.WriteLine("Ingrese la descripción del producto:");
        string descripcion = Console.ReadLine();

        Console.WriteLine("Ingrese el precio del producto:");
        if (!decimal.TryParse(Console.ReadLine(), out decimal precio))
        {
            Console.WriteLine("Formato de precio inválido. Inténtelo nuevamente.");
            return;
        }

        Console.WriteLine("Ingrese la cantidad en stock:");
        if (!int.TryParse(Console.ReadLine(), out int stock))
        {
            Console.WriteLine("Formato de cantidad inválido. Inténtelo nuevamente.");
            return;
        }

        productoservices.Insertar(new Producto
        {
            Nombre = nombre,
            Descripcion = descripcion,
            Precio = precio,
            Stock = stock
        });

        Console.WriteLine("Producto insertado correctamente.");
    }

    private static void ListarProductos(ProductoServices productoservices)
    {
        var productos = productoservices.GetAll().ToList();

        if (productos.Any())
        {
            Console.WriteLine("Listado de productos:");
            foreach (var producto in productos)
            {
                Console.WriteLine($"ID: {producto.Id}");
                Console.WriteLine($"Nombre: {producto.Nombre}");
                Console.WriteLine($"Descripción: {producto.Descripcion}");
                Console.WriteLine($"Precio: {producto.Precio}");
                Console.WriteLine($"Stock: {producto.Stock}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No hay productos registrados.");
        }
    }

    private static void ActualizarProducto(ProductoServices productoservices)
    {
        Console.WriteLine("Ingrese el ID del producto que desea actualizar:");
        if (!int.TryParse(Console.ReadLine(), out int idProducto))
        {
            Console.WriteLine("Formato de ID inválido. Intente nuevamente.");
            return;
        }

        try
        {
            Producto productoExistente = productoservices.GetProductoById(idProducto);

            if (productoExistente == null)
            {
                Console.WriteLine($"No se puede actualizar el producto con ID {idProducto} porque no existe.");
                return;
            }

            Console.WriteLine("Ingrese el nombre del producto:");
            productoExistente.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese la descripción del producto:");
            productoExistente.Descripcion = Console.ReadLine();

            Console.WriteLine("Ingrese el precio del producto:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal precio))
            {
                Console.WriteLine("Formato de precio inválido. Inténtelo nuevamente.");
                return;
            }
            productoExistente.Precio = precio;

            Console.WriteLine("Ingrese la cantidad en stock:");
            if (!int.TryParse(Console.ReadLine(), out int stock))
            {
                Console.WriteLine("Formato de cantidad inválido. Inténtelo nuevamente.");
                return;
            }
            productoExistente.Stock = stock;

            bool actualizado = productoservices.Update(productoExistente);

            if (actualizado)
            {
                Console.WriteLine("Producto actualizado correctamente.");
            }
            else
            {
                Console.WriteLine("No se pudo actualizar el producto.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al intentar actualizar el producto: {ex.Message}");
        }
    }

    public  void EliminarProducto(ProductoServices productoservices)
    {
        Console.WriteLine("Ingrese el ID del producto que desea eliminar:");
        if (!int.TryParse(Console.ReadLine(), out int idProducto))
        {
            Console.WriteLine("Formato de ID inválido. Intente nuevamente.");
            return;
        }

        try
        {
            productoservices.EliminarProducto(idProducto);
            Console.WriteLine("Producto eliminado correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al intentar eliminar el producto: {ex.Message}");
        }
    }
}


