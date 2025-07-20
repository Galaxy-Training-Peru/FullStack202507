using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RefAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Uso de ref en métodos async ===");
            await ProcessDataAsync();
        }

        // Método asíncrono que usa ref struct (ReadOnlySpan<T>)
        static async Task ProcessDataAsync()
        {
            // Buffer de ejemplo
            int[] data = { 10, 20, 30, 40, 50 };

            // Uso de ref struct (ReadOnlySpan<int>)
            ReadOnlySpan<int> span = data;

            ref readonly int firstElement = ref span[0]; // Primer elemento como ref readonly
            Console.WriteLine($"Primer elemento: {firstElement}");

            // No puedes cruzar límites await con variables ref
            await Task.Delay(100); // Correcto, pero no puedes acceder a "firstElement" aquí.

            Console.WriteLine("Después del await.");
        }
    }
}
