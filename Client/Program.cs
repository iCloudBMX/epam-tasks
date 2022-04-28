using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:8888/");

            var response = await httpClient.GetAsync("MyNameByHeader");

            var myName = response.Headers.GetValues("X-MyName")?.First();

            Console.WriteLine($"My name is {myName}");

            Console.ReadKey();
        }
    }
}
