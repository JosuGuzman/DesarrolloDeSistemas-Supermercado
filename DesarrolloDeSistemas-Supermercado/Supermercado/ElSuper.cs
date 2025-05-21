namespace Supermercado;

public class ElSuper
{
    private Dictionary<string, Articulos> Productos;

    public ElSuper() => Productos = new Dictionary <string, Articulos>() ;

    public void DarDeAlta(Articulos nuevoProducto)
    {
        if (Productos.ContainsKey(nuevoProducto.CodigoBarra))
        {
            Productos[nuevoProducto.CodigoBarra].AgregarStock(nuevoProducto.Stock);
            Console.WriteLine($"🔄 Stock actualizado para '{nuevoProducto.Nombre}'.");
        }
        else
        {
            Productos.Add(nuevoProducto.CodigoBarra, nuevoProducto);
            Console.WriteLine($"✅ Producto '{nuevoProducto.Nombre}' agregado correctamente.");
        }
    }

    public void ModificarProducto(string barcode, decimal nuevoPrecio, DateTime? nuevaFechaVencimiento)
    {
        if (Productos.TryGetValue(barcode, out Articulos producto))
        {
            producto.PrecioUnitario = nuevoPrecio;
            producto.FechaVencimiento = nuevaFechaVencimiento;
            Console.WriteLine($"✏️ Producto '{producto.Nombre}' modificado con éxito.");
        }
        else
        {
            Console.WriteLine("❌ No se encontró el producto para modificar.");
        }
    }

    public void DarDeBaja(string barcode)
    {
        if (Productos.Remove(barcode))
        {
            Console.WriteLine("Producto Eliminado con Exito");
        }
        else{

        }
    }

    public Articulos Buscar(string codigo)
    {
        if (Productos.TryGetValue(codigo, out Articulos articulo))
        {
            return articulo;
        }
        Console.WriteLine("🔎 Producto no encontrado.");
        return null;
    }

    public void MostrarVencidos()
    {
        Console.WriteLine("⚠️ Productos vencidos:");
        var vencidos = Productos.Values.Where(p => p.EstaVencido()).ToList();
        if (vencidos.Count == 0)
        {
            Console.WriteLine("🎉 No hay productos vencidos.");
            return;
        }

        foreach (var p in vencidos)
        {
            Console.WriteLine(p);
            Console.WriteLine("──────────────────────");
        }
    }

}