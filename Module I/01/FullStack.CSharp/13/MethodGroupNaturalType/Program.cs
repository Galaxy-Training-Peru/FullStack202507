using System;

namespace MethodGroupNaturalType
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Antes de C# 13 ===");
            BeforeCSharp13();

            Console.WriteLine("\n=== Con C# 13 ===");
            WithCSharp13();
        }

        // Simulación del comportamiento anterior
        static void BeforeCSharp13()
        {
            // Solución en versiones anteriores: Usar una lambda para desambiguar
            Process(x => Print(x)); // Funciona especificando con lambda.
        }

        // Comportamiento mejorado en C# 13
        static void WithCSharp13()
        {
            // Con C# 13, el compilador selecciona automáticamente la sobrecarga correcta.
            Process(Print); // Ahora funciona sin necesidad de lambda.
        }

        // Sobrecarga específica: Método que acepta un entero
        static void Print(int x)
        {
            Console.WriteLine($"Entero: {x}");
        }

        // Sobrecarga genérica
        static void Print<T>(T x)
        {
            Console.WriteLine($"Genérico: {x}");
        }

        // Método que recibe un delegado del tipo Action<int>
        static void Process(Action<int> action)
        {
            // Ejecuta el delegado
            action(42);
        }
    }
}
