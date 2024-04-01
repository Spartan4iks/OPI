using System;
using System.IO;
using System.Linq;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Number of points: ");
        int n = int.Parse(Console.ReadLine());
        double[] x = new double[n];
        double[] y = new double[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"x[{i}] = ");
            x[i] = double.Parse(Console.ReadLine());
            Console.Write($"y[{i}] = ");
            y[i] = double.Parse(Console.ReadLine());
        }

        Console.WriteLine("Choose functions for approximate:");
        Console.WriteLine("1. f(x) = x");
        Console.WriteLine("2. f(x) = x * cos(x)");
        Console.WriteLine("3. f(x) = sin(x)");
        Console.Write("Write a number: ");
        int choice = int.Parse(Console.ReadLine());
        double[,] a = new double[3, 3];
        double[] b = new double[3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                a[i, j] = Enumerable.Range(0, n).Sum(k => Math.Pow(x[k], i + j));
            }
            b[i] = Enumerable.Range(0, n).Sum(k => y[k] * Math.Pow(x[k], i));
        }
        double[] c = new double[3];
        for (int i = 0; i < 3; i++)
        {
            c[i] = Enumerable.Range(0, 3).Sum(j => a[i, j] * b[j]) / a[i, i];
        }

        double a1 = (y.Max() - y.Min()) / (x.Max() - x.Min());
        double b1 = y.Average() - a1 * x.Average();

        double s1 = y.Average();

        Console.WriteLine("Input dots for apprx:");
        Console.Write("x1 = ");
        double inputX1 = double.Parse(Console.ReadLine());
        Console.Write("y1 = ");
        double y1 = double.Parse(Console.ReadLine());
        Console.Write("x2 = ");
        double inputX2 = double.Parse(Console.ReadLine());
        Console.Write("y2 = ");
        double y2 = double.Parse(Console.ReadLine());
        double a2 = (y2 - y1) / (inputX2 - inputX1);
        double b2 = y1 - a2 * inputX1;

        Console.WriteLine();
        Console.WriteLine($"Coefficients of approximating point: a0 = {c[0]}, a1 = {c[1]}, a2 = {c[2]}");
        Console.WriteLine($"Linear approximation: y = {a1} * x + {b1}");
        Console.WriteLine($"Static approximation: y = {s1}");
        Console.WriteLine($"Approximation of points set: y = {a2} * x + {b2}");

        var plotModel = new PlotModel { Title = "" };
        var pointsSeries = new ScatterSeries { MarkerType = MarkerType.Circle };
        var linearSeries = new FunctionSeries(xVal => a1 * xVal + b1, x.Min(), x.Max(), 0.1, "Linear approximation");
        var staticSeries = new FunctionSeries(xVal => s1, x.Min(), x.Max(), 0.1, "Static approximation");
        var customSeries = new FunctionSeries(xVal => c[0] * xVal + c[1] * xVal * Math.Cos(xVal) + c[2] * Math.Sin(xVal), x.Min(), x.Max(), 0.1, "Approximation of points set");

        string filename = "filename.pdf";
        for (int i = 0; i < n; i++)
        {
            pointsSeries.Points.Add(new ScatterPoint(x[i], y[i], 5) { Tag = "Point" });
        }
        plotModel.Series.Add(pointsSeries);
        plotModel.Series.Add(linearSeries);
        plotModel.Series.Add(staticSeries);
        plotModel.Series.Add(customSeries);
        plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "x" });
        plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "y" });
        using (var stream = File.Create(filename))
        {
            var pdfExporter = new PdfExporter { Width = 600, Height = 400 };
            pdfExporter.Export(plotModel, stream);
        }
    }
}
