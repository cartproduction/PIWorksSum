using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    static class Program
    {
        static void Main(string[] args)
        {

            int i=0,j=0;
            var sumList = new List<int>();
            var numbers = new List<int>();
            string[] lines = System.IO.File.ReadAllLines("../TextFile1.txt");
            int[,] Pyramidarray2D = new int[lines.Length, lines.Length];
            foreach (string line in lines)
            {
                numbers = line.Split(' ').Select(Int32.Parse).ToList();
                
                foreach (int n in numbers)
                {
                    Pyramidarray2D[i, j] = n;
                    j++;
                        
                }
                j = 0;
                i++;
            }

            int result = CalculateDiagonalNonPrimeNumbers(Pyramidarray2D);
            Console.WriteLine(string.Format("The maximum summation of non-prime numbers from top to bottom: {0}", result));
            Console.ReadKey();


        }

        private static int CalculateDiagonalNonPrimeNumbers(int[,] Pyramidarray2D)
        {
            int quantityOfRows = Pyramidarray2D.GetLength(0);

            for (int a = 0; a < quantityOfRows; a++)
            {
                for (int b = 0; b < quantityOfRows; b++)
                {
                    if (!IsNumberPrime(Pyramidarray2D[a, b]))
                        Pyramidarray2D[a, b] = 0;

                }
            }

            for (int i = quantityOfRows-2; i >= 0; i--)
            {
                for (int j = 0; j < quantityOfRows-1; j++)
                {
                    Pyramidarray2D[i, j] = Math.Max(Pyramidarray2D[i, j] + Pyramidarray2D[i + 1, j], Pyramidarray2D[i, j] + Pyramidarray2D[i + 1, j + 1]);
                }
            }
            Console.WriteLine(string.Format("Maximum total: {0}", Pyramidarray2D[0, 0]));

            return Pyramidarray2D[0, 0];
        }

        public static bool IsNumberPrime(this int number)
        {
            // Test whether the parameter is a prime number.
            if (number == 0 || number == 1)
            {

                return true;
            }
            else
            {
                for (int a = 2; a <= number / 2; a++)
                {
                    if (number % a == 0)
                    {

                        return true;
                    }

                }
                return false;
            }
        }
    }
}
