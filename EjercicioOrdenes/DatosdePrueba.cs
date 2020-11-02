using System;
using System.Collections.Generic;
public class DatosdePrueba
{
    public List<Producto> ListadeProductos { get; set; }
    public List<Cliente> ListadeClientes { get; set; }
    public List<Vendedor> ListadeVendedores { get; set; }
    public List<Orden> ListaOrdenes { get; set; }

    public DatosdePrueba()
    {
        ListadeProductos = new List<Producto>();      
        cargarProductos();   

        ListadeClientes = new List<Cliente>();
        cargarClientes();

        ListadeVendedores = new List<Vendedor>();
        cargarVendedores();

        ListaOrdenes = new List<Orden>();
    }

    private void cargarProductos()
    {
        Producto p1 = new Producto(1, "Mouse", 250);
        ListadeProductos.Add(p1);

        Producto p2 = new Producto(2, "Monitor", 5000);
        ListadeProductos.Add(p2);

        Producto p3 = new Producto(3, "Teclado", 450);
        ListadeProductos.Add(p3);

        Producto p4 = new Producto(4, "Playstation 4", 10000);
        ListadeProductos.Add(p4);
     }
     private void cargarClientes(){
         Cliente c1 = new Cliente(1, "Juan", "96745631");
         ListadeClientes.Add(c1);

         
         Cliente c2 = new Cliente(2, "Carlos", "96756731");
         ListadeClientes.Add(c2);
     }

     private void cargarVendedores(){
         Vendedor v1 = new Vendedor (1, "Marcos", "001");
         ListadeVendedores.Add(v1);

         Vendedor v2 = new Vendedor (2, "Pedro", "002");
         ListadeVendedores.Add(v2);
     }

     public void ListarProductos()
     {
         Console.Clear();
         Console.WriteLine("Lista de Productos");
         Console.WriteLine("==================");
         Console.WriteLine("");
         foreach (var producto in ListadeProductos)
         {
             Console.WriteLine(producto.Codigo + " | " + producto.Descripcion + " | " + producto.Precio);
         }
         Console.ReadLine();
     }

     public void ListarClientes()
     {
         Console.Clear();
         Console.WriteLine("Lista de Clientes");
         Console.WriteLine("=================");
         Console.WriteLine("");
         foreach (var cliente in ListadeClientes)
         {
             Console.WriteLine(cliente.Codigo + " | " + cliente.Nombre + " | " + cliente.Telefono);
         }
         Console.ReadLine();
     }

     public void ListarVendedores()
     {
         Console.Clear();
         Console.WriteLine("Lista de Vendedores");
         Console.WriteLine("====================");
         Console.WriteLine("");
         foreach (var vendedor in ListadeVendedores)
         {
             Console.WriteLine(vendedor.Codigo + " | " + vendedor.Nombre + " | " + vendedor.CodigoVendedor);
         }
         Console.ReadLine();
     }

     public void CrearOrden()
     {
        Console.WriteLine("Creando Orden");
        Console.WriteLine("=============");
        Console.WriteLine("");

        Console.WriteLine("Ingrese el codigo del cliente: ");
        string codigoCliente = Console.ReadLine();

        Cliente cliente = ListadeClientes.Find(c => c.Codigo.ToString() == codigoCliente);
        if(cliente == null)
        {
            Console.WriteLine("Cliente no encontrado");
            Console.ReadLine();
            return;
        }else {
            Console.WriteLine("Cliente: " + cliente.Nombre);
            Console.WriteLine("");
        }
        Console.WriteLine("Ingrese el codigo del vendedor: ");
        string codigoVendedor = Console.ReadLine();

        Vendedor vendedor = ListadeVendedores.Find(v => v.Codigo.ToString() == codigoVendedor);
        if(vendedor == null)
        {
            Console.WriteLine("Vendendor no encontrado");
            Console.ReadLine();
            return;
        } else {
            Console.WriteLine("Vendedor: " + vendedor.Nombre );
            Console.WriteLine("");
        }
         int nuevoCodigo = ListaOrdenes.Count + 1;

         Orden nuevaOrden = new Orden(1, DateTime.Now, "SPS" + nuevoCodigo, cliente, vendedor);
         ListaOrdenes.Add(nuevaOrden);

         while(true)
         {
            Console.WriteLine("Ingrese el producto: ");
            string codigoProducto = Console.ReadLine();

            Producto producto = ListadeProductos.Find(p => p.Codigo.ToString() == codigoProducto);
            if(producto == null)
            {
                Console.WriteLine("Producto no encontrado");
                Console.ReadLine();
             } else {
                 Console.WriteLine("Producto agregado: " + producto.Descripcion + " su precio es: " + producto.Precio);
                 nuevaOrden.AgregarProducto(producto);
             }
            Console.WriteLine("Desea continuar? s/n");
            string continuar = Console.ReadLine();
            if (continuar.ToLower() == "n")
            {
                break;
            }
         }
         Console.WriteLine("");
         Console.WriteLine("Subtotal: " + nuevaOrden.Subtotal);
         Console.WriteLine("Impuesto del 15% : " + nuevaOrden.Impuestos);
         Console.WriteLine("TOTAL DE LA ORDEN ES DE: " + nuevaOrden.Total);
         Console.ReadLine();
     }
     public void ListarOrdenes()
     {
        Console.Clear();
        Console.WriteLine("Lista de Ordenes");
        Console.WriteLine("==================");
        Console.WriteLine("");

        foreach (var orden in ListaOrdenes)
        {
            Console.WriteLine(orden.Codigo + " | " + orden.Fecha);
            Console.WriteLine("Subtotal: " + orden.Subtotal + " | " + "Impuestos: " + orden.Impuestos +  " | " + "Total: " + orden.Total);
            Console.WriteLine("Cliente: " + orden.Cliente.Nombre + " | " + "Vendedor: " + orden.Vendedor.Nombre);
            foreach (var detalle in orden.ListaOrdenDetalle)
            {
                Console.WriteLine("    " + detalle.Producto.Descripcion + " | " + detalle.Cantidad + " | " + detalle.Precio);           
            }
        }
        Console.ReadLine();
     }
}