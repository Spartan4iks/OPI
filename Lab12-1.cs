using System;
using System.Threading;

class Program
{
    static double TgSquared(double x, int n)
    {
        double result = 0;
        double term = 1;

        for (int i = 1; i <= n; i++)
        {
            term *= 2 * Math.Tan(Math.PI * x / 180) / (2 * i - 1);
            if (i % 2 == 0)
                result += term;
            else
                result -= term;
        }

        return result;
    }

    static double TgSquaredWithPrecision(double x, double precision)
    {
        double resultOdd = 0;
        double resultEven = 0;
        int n = 1;
        double term = 1;

        while (Math.Abs(term) > precision)
        {
            term = 2 * Math.Tan(Math.PI * x / 180) / (2 * n - 1);
            if (n % 2 == 0)
                resultEven += term;
            else
                resultOdd -= term;
            n++;
        }

        return resultOdd * resultOdd;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Введiть x у градусах:");
        double x = double.Parse(Console.ReadLine());

        Console.WriteLine("Введiть кiлькiсть iтерацiй:");
        int iterations = int.Parse(Console.ReadLine());

        Console.WriteLine("Введiть точнiсть:");
        double precision = double.Parse(Console.ReadLine());

        // Parallel execution for odd and even terms
        Task<double> oddTask = Task.Run(() => TgSquared(x, iterations));
        Task<double> evenTask = Task.Run(() => TgSquared(x, iterations));

        Task.WaitAll(oddTask, evenTask);

        double result = oddTask.Result + evenTask.Result;
        Console.WriteLine($"Використання результату {iterations} iтерацiй: {result}");

        // Calculating with precision
        double resultWithPrecision = TgSquaredWithPrecision(x, precision);
        Console.WriteLine($"Результат з точнiстю {precision}: {resultWithPrecision}");
    }
}
