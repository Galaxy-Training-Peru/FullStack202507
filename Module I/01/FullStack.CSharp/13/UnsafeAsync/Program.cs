using System;
using System.Collections.Generic;

namespace RefAndUnsafeExample
{
    //<AllowUnsafeBlocks>true</AllowUnsafeBlocks>   
    class Program
    {
        static unsafe void Main(string[] args)
        {
            Console.WriteLine("=== Uso de unsafe en métodos iteradores ===");
            foreach (var value in UnsafeIterator())
            {
                Console.WriteLine(value);
            }
        }

        // Método iterador seguro que usa una lista generada con punteros
        static IEnumerable<int> UnsafeIterator()
        {
            foreach (var value in GetValuesWithPointers())
            {
                yield return value; // yield trabaja con valores ya procesados
            }
        }

        // Método unsafe que trabaja con punteros y devuelve los resultados
        static unsafe List<int> GetValuesWithPointers()
        {
            int[] values = { 1, 2, 3, 4, 5 };
            List<int> results = new List<int>();

            fixed (int* ptr = values) // Bloque que fija la memoria
            {
                for (int i = 0; i < values.Length; i++)
                {
                    results.Add(*(ptr + i)); // Acceso seguro a través del puntero
                }
            }

            return results; // Devuelve los valores procesados
        }
    }
}
