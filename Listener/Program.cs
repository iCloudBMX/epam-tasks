using System;
using System.Net.Http;

namespace Listener
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:8888/");

            var response = httpClient.GetAsync("/MyName").Result;

            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }
    }
}
