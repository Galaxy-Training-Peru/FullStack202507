void Concat<T>(params ReadOnlySpan<T> items)
{
    for (int i = 0; i < items.Length; i++)
    {
        Console.Write(items[i]);
        Console.Write(" ");
    }
    Console.WriteLine();
}

// Llamando al método:
var array = new[] { 1, 2, 3, 4, 5 };
var span = new ReadOnlySpan<int>(array);

// Usando el método:
Concat(span); // Salida: 1 2 3 4 5
