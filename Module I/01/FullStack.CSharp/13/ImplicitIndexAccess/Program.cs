public class TimerRemaining
{
    // Arreglo con 10 elementos
    public int[] buffer { get; set; } = new int[10];
}

public class Program
{
    public static void Main()
    {

        //Antes de C# 13 
        var countdownOld = new TimerRemaining()
        {
            buffer =
            {
                [0] = 9,
                [1] = 8,
                [2] = 7,
                [3] = 6,
                [4] = 5,
                [5] = 4,
                [6] = 3,
                [7] = 2,
                [8] = 1,
                [9] = 0
            }
        };

        // Mostrar los valores en el arreglo
        Console.WriteLine("Antes de C# 13");
        foreach (var value in countdownOld.buffer)
        {
            Console.WriteLine(value);
        }

        //Con C# 13
        var countdown = new TimerRemaining()
        {
            buffer =
            {
                [^1] = 0, // Último elemento
                [^2] = 1, // Penúltimo elemento
                [^3] = 2,
                [^4] = 3,
                [^5] = 4,
                [^6] = 5,
                [^7] = 6,
                [^8] = 7,
                [^9] = 8,
                [^10] = 9 // Primer elemento
            }
        };

        // Mostrar los valores en el arreglo
        Console.WriteLine("Con C# 13");
        foreach (var value in countdown.buffer)
        {
            Console.WriteLine(value);
        }
    }
}
