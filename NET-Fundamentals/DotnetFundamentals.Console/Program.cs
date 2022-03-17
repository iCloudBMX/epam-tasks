using System;

namespace DotnetFundamentals.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            string username = Console.ReadLine();

            if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
            {
                Console.WriteLine($"Username cannot be null or white space");
                return;
            }

            Console.WriteLine($"Hello {username}");
        }
    }
}