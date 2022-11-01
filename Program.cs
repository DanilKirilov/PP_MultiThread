using System;
using System.Threading;

internal class Program
{
    private static void Main(string[] args)
    {
        Random random = new();
        int n = 7; // кол-во потоков
        int N = random.Next(1, 10); // кол-во элементов
        int[] a = new int[N];
        
        for (int i = 0; i < a.Length; i++)
        {
            a[i] = random.Next(1, 10);
        }
        int[] returns = new int[n];
        Thread[] thread = new Thread[n];
        for (int i = 0; i < thread.Length; i++)
        {

            thread[i] = new Thread(() => { returns[i] = (ThreadFunc(a, i, n)); });
            thread[i].Start();
            thread[i].Join();

        }
        int multiply = 1;
        for (int i = 0; i < returns.Length; i++)
        {
            multiply *= returns[i];
        }
        Console.WriteLine($"Произведение элементов: {multiply}");
        Console.ReadKey();
    }

    static int ThreadFunc(object param, object totalI, object N)
    {
        int beg, h, end;
        int multiply = 1;
        int[]? a = param as int[];
        int nt = Convert.ToInt32(totalI);
        int count = Convert.ToInt32(N);
        h = a.Length / count;
        beg = h * nt; end = beg + h;
        if (nt == count - 1)
        {
            end = a.Length;
        }
        for (int i = beg; i < end; i++)
        {
            multiply *= a[i];
        }
        return multiply;
    }

}