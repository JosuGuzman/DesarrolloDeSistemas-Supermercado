using Supermercado;

class Program
{
    static void Main(string[] args)
    {
        ElSuper gestor = new ElSuper();
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("🛒 SISTEMA DE GESTIÓN DE STOCK - MINI SUPER ET12");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("1. Dar de alta producto");
            Console.WriteLine("2. Modificar producto");
            Console.WriteLine("3. Dar de baja producto");
            Console.WriteLine("4. Buscar producto");
            Console.WriteLine("5. Mostrar todos los productos");
            Console.WriteLine("6. Mostrar productos vencidos");
            Console.WriteLine("0. Salir:");
            Console.Write("📌 Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AltaProducto(gestor);
                    break;
                case "2":
                    ModificarProducto(gestor);
                    break;
                case "3":
                    BajaProducto(gestor);
                    break;
                case "4":
                    BuscarProducto(gestor);
                    break;
                case "5":
                    gestor.MostrarTodos();
                    Pausa();
                    break;
                case "6":
                    gestor.MostrarVencidos();
                    Pausa();
                    break;
                case "0":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("❌ Opción inválida.");
                    Pausa();
                    break;
            }
        }

        Console.WriteLine("👋 Gracias por usar el sistema. ¡Hasta luego!");
    }

    static void AltaProducto(ElSuper gestor)
    {
        Console.Write("Código de barras: ");
        string barcode = Console.ReadLine();

        Console.Write("Nombre del producto: ");
        string nombre = Console.ReadLine();

        Console.Write("Stock inicial: ");
        int stock = int.Parse(Console.ReadLine());

        Console.Write("Precio unitario: ");
        decimal precio = decimal.Parse(Console.ReadLine());

        Console.Write("Proveedor: ");
        string proveedor = Console.ReadLine();

        Console.Write("Fecha de vencimiento (yyyy-mm-dd o enter si no aplica): ");
        string vencimientoInput = Console.ReadLine();
        DateTime? vencimiento = string.IsNullOrWhiteSpace(vencimientoInput)
            ? null
            : DateTime.Parse(vencimientoInput);

        Console.Write("Categoría: ");
        string categoria = Console.ReadLine();

        var producto = new Articulos(barcode, nombre, stock, precio, vencimiento, categoria);
        gestor.DarDeAlta(producto);
        Pausa();
    }

    static void ModificarProducto(ElSuper gestor)
    {
        Console.Write("Código del producto a modificar: ");
        string barcode = Console.ReadLine();

        Console.Write("Nuevo precio: ");
        decimal precio = decimal.Parse(Console.ReadLine());

        Console.Write("Nuevo vendedor ");
        string proveedor = Console.ReadLine();

        Console.Write("Nueva fecha de vencimiento (yyyy-mm-dd o enter si no aplica): ");
        string vencimientoInput = Console.ReadLine();
        DateTime? vencimiento = string.IsNullOrWhiteSpace(vencimientoInput)
            ? null
            : DateTime.Parse(vencimientoInput);

        gestor.ModificarProducto(barcode, precio, proveedor, vencimiento);
        Pausa();
    }

    static void BajaProducto(ElSuper gestor)
    {
        Console.Write("Código del producto a eliminar: ");
        string codigo = Console.ReadLine();
        gestor.DarDeBaja(codigo);
        Pausa();
    }

    static void BuscarProducto(ElSuper gestor)
    {
        Console.Write("Código del producto a buscar: ");
        string codigo = Console.ReadLine();
        var producto = gestor.Buscar(codigo);
        if (producto != null)
        {
            Console.WriteLine(producto);
        }
        Pausa();
    }

    static void Pausa()
    {
        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey();
    }
}
