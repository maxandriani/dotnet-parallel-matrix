using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOperations
{
    public static class MatrixExtensions
    {
        public static void Print(this double[,] matrix)
        {
            var headerLine = "";
            var bodyLine = "";
            var cols = matrix.GetLength(1);
            var rows = matrix.GetLength(0);

            for (int row = 0; row < rows; row++)
            {
                var body = "";
                var header = "";

                for (int col = 0; col < cols; col++)
                {
                    body += $"{matrix[row, col].ToString("000.0")} ";
                    header += $"C {col.ToString("000")} ";
                }

                body = $"Row {row.ToString("000")}: {body}";
                header = $"         {header}";

                if (string.IsNullOrEmpty(headerLine))
                {
                    headerLine = string.Join("", body.Select(x => "="));
                    bodyLine = string.Join("", body.Select(x => "-"));
                }
                
                if (row == 0)
                {
                    Console.WriteLine(headerLine);
                    Console.WriteLine(header);
                }

                Console.WriteLine(bodyLine);
                Console.WriteLine(body);

            }

            Console.WriteLine(bodyLine);
            Console.WriteLine();
        }

        public static void FillRandom(this double[,] matrix)
        {
            var rand = new Random();
            var cols = matrix.GetLength(1);
            var rows = matrix.GetLength(0);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rand.Next(100);
                }
            }
        }
    }
}
