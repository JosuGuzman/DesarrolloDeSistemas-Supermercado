namespace Supermercado;

public class Articulos
{
    public string CodigoBarra {get; set;} // Clave del Diccionario
    public string Nombre {get; set;}
    public uint Stock {get; set;}
    public decimal PrecioUnitario {get; set;}
    public DateTime? FechaVencimiento {get; set;}
    public bool EsPerecedero => FechaVencimiento.HasValue;
    public string Categoria {get; set;}

    public Articulos (string nombre, uint stock, decimal precio, string barcode, string categoria)
    {
        CodigoBarra = barcode;
        Nombre = nombre;
        Stock = stock;
        PrecioUnitario = precio;
        Categoria = categoria;
    }

    // Método para aumentar stock
    public void AgregarStock(uint cantidad)
    {
        if (cantidad <= 0)
            throw new ArgumentException("La cantidad debe ser mayor que cero.");

        Stock += cantidad;
    }

    // Método para reducir stock
    public void DescontarStock(uint cantidad)
    {
        if (cantidad <= 0)
            throw new ArgumentException("La cantidad debe ser mayor que cero.");

        if (cantidad > Stock)
            throw new InvalidOperationException("No hay suficiente stock.");

        Stock -= cantidad;
    }

    // 🧾 Método para calcular el valor total del stock
    public decimal CalcularValorTotal()
    {
        return Stock * PrecioUnitario;
    }

    // ⚠️ Método para saber si está vencido
    public bool EstaVencido()
    {
        return EsPerecedero && FechaVencimiento < DateTime.Today;
    }

    // Método para mostrar los datos
    public override string ToString()
    {
        return  $"📦 {Nombre} ({CodigoBarra})\n" +
                $"- Stock: {Stock} unidades\n" +
                $"- Precio unitario: ${PrecioUnitario}\n" +
                $"- Valor total en stock: ${CalcularValorTotal()}\n" +
                $"- Vence: {(EsPerecedero ? FechaVencimiento.Value.ToShortDateString() : "No perecedero")}\n" +
                $"- Estado: {(EstaVencido() ? "❌ VENCIDO" : "✅ Vigente")}\n" +
                $"- Categoría: {Categoria}";
    }
}
