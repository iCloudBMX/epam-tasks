using System;

namespace DotnetFundamentals.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = args[0];

            Console.WriteLine($"Hello {username}");
        }
    }
}