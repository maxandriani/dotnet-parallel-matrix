using System;
using System.Diagnostics;

namespace MatrixOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Flow();
                Console.WriteLine("Do you want to try again? (Y/n)");
            } while (char.ToUpperInvariant(Console.ReadKey().KeyChar) != 'N');
        }

        static void Flow()
        {
            Console.WriteLine("Welcome to Matrix Tools 😍");

            var (rows, leftCols, rightCols) = SetupMatrix();

            var left = new double[rows, leftCols];
            var right = new double[rows, rightCols];
            var result = new double[rows, rightCols];
            var stopwatch = new Stopwatch();
            double sequencialTime;
            double parallelTime;

            left.FillRandom();
            right.FillRandom();

            DoYouWantPrintMatrix(left, "Left");
            DoYouWantPrintMatrix(right, "Right");

            stopwatch.Start();
            left.Multiply(right, result);
            stopwatch.Stop();
            sequencialTime = stopwatch.Elapsed.TotalMilliseconds;

            DoYouWantPrintMatrix(result, "Sequencial Result");

            result = new double[rows, rightCols];
            stopwatch.Reset();
            stopwatch.Start();
            left.MultiplyAsParallel(right, result);
            stopwatch.Stop();
            parallelTime = stopwatch.Elapsed.TotalMilliseconds;

            DoYouWantPrintMatrix(result, "Parallel Result");

            Console.WriteLine("=================================");
            Console.WriteLine($"Sequencial     {sequencialTime}");
            Console.WriteLine($"Parallel       {parallelTime}");
            Console.WriteLine("=================================");
            Console.ReadKey();
        }

        static (int Rows, int LeftCols, int RightCols) SetupMatrix()
        {
            int leftCols;
            int rightCols;
            int rows;

            Console.WriteLine("Set up matrices. Use small values to better view");
            Console.WriteLine("Increase the counts to see greater speedup in the parallel loop vs. the sequential loop.");

            do
            {
                Console.WriteLine("Enter the size of Left Matrix (cols): ");
            } while (!int.TryParse(Console.ReadLine(), out leftCols));

            do
            {
                Console.WriteLine("Enter the size of Right Matrix (cols): ");
            } while (!int.TryParse(Console.ReadLine(), out rightCols));

            do
            {
                Console.WriteLine("Enter the number of rows: ");
            } while (!int.TryParse(Console.ReadLine(), out rows));

            return (rows, leftCols, rightCols);
        }

        static void DoYouWantPrintMatrix(double[,] matrix, string name)
        {
            Console.WriteLine($"Do you want to print the matrix {name} (y/N)?");
            var response = Console.ReadKey().KeyChar;

            if (char.ToUpperInvariant(response) == 'Y')
            {
                matrix.Print();
                Console.ReadKey();
            }
        }
    }
}
