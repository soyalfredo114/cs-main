using System;

namespace inventario
{
    class Program
    {   
        static void Main(string[] args)
        {
            string opcion = "";
            Inventario inventario = new Inventario();
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Sistema de Inventario");
                Console.WriteLine("*********************");
                Console.WriteLine("");
                Console.WriteLine("1 - Productos");
                Console.WriteLine("2 - Entrada de Inventario");
                Console.WriteLine("3 - Salida de Inventario");
                Console.WriteLine("4 - Ajuste Positivo de Inventario");
                Console.WriteLine("5 - Ajuste Negativo de Inventario");
                Console.WriteLine("0 - Salir");
                Console.WriteLine("Ingrese la opcion del Menu: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                    inventario.listarProductos();
                    Console.ReadLine();
                    break;
                    
                    case "2":
                    inventario.aumentoInventario();
                    break;

                    case "3":
                    inventario.disminucionInventario();
                    break;

                    case "4":
                    inventario.ajustePositivo();
                    break;

                    case "5":
                    inventario.ajusteNegativo();
                    break;

                    default:
                    break;

                }
            if (opcion == "0") {
                break;
            }
            }
            
        }
    }
}
