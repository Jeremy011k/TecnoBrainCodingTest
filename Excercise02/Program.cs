using System;
using System.Numerics;
using Excercise01;

namespace Excercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BigInteger input;
            if (!BigInteger.TryParse(Console.ReadLine(), out input))
            { Console.WriteLine("Invalid number format");
                return;
            }
            string response = input.InWords();
            Console.WriteLine(response);
            Console.ReadKey();
        }
    }
}
