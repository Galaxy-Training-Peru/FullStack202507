using System;
using System.Threading;

class Program
{
    static Lock myLock = new();

    static void Main()
    {
        // Simulando múltiples hilos
        Parallel.Invoke(
            () => CriticalSection(),
            () => CriticalSection(),
            () => CriticalSection()
        );
    }

    static void CriticalSection()
    {
        using (myLock.EnterScope()) // Bloqueo exclusivo con Lock.EnterScope()
        {
            Console.WriteLine($"Inicio: {DateTime.Now.Ticks}");
            Thread.Sleep(1000); // Simula trabajo dentro de la sección crítica
            Console.WriteLine($"Fin: {DateTime.Now.Ticks}");
        }
    }
}
