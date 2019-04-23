using System;
using System.Diagnostics;

namespace MatrixMultiplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter matrix multiplication type: \n 1:Sequential 2:Parallel.For 3:Multiple Tasks \n Press Ctrl-Z to exit!");
            const int size = 2;

            while (true)
            {

                var input = Convert.ToInt32(Console.ReadLine());

                var (m1, m2) = InitializeInputMatrix(size);
                var sw = Stopwatch.StartNew();

                switch (input)
                {
                    case 1:
                        {
                            Console.WriteLine("Running Sequential operation");
                            MultiplySequentially(size, m1, m2);
                            Console.WriteLine($"Operation took {sw.ElapsedMilliseconds} ms");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Running Parallel.For operation");
                            // Implement using Parallel.For
                            Console.WriteLine($"Operation took {sw.ElapsedMilliseconds} ms");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Running Multiple Tasks operation");
                            // Implement using multiple tasks
                            Console.WriteLine($"Operation took {sw.ElapsedMilliseconds} ms");
                            break;
                        }
                    default: throw new InvalidOperationException();
                }
            }
        }

        private static (int[,] m1, int[,] m2) InitializeInputMatrix(int size)
        {
            int[,] m1 = new int[size, size];
            int[,] m2 = new int[size, size];

            var random = new Random();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    m1[i, j] = random.Next(1, 100);
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    m2[i, j] = random.Next(1, 100);
                }
            }

            return (m1, m2);
        }


        public static int[,] MultiplySequentially(int size, int[,] m1, int[,] m2)
        {
            var result = new int[size, size];
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    var tmp = 0;
                    for (var k = 0; k < size; k++)
                    {
                        tmp += m1[i, k] * m2[k, j];
                    }
                    result[i, j] = tmp;
                }
            }

            return result;
        }
    }
}
