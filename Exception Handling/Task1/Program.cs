using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            foreach(string value in input)
            {
                try
                {
                    Console.WriteLine(value[0]);
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}