using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Listener
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string[] urls = { "/Information", "/Success", "/Redirection", "/ClientError", "/ServerError" };

            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:8888/");

            foreach (var url in urls)
            {                  
                Console.WriteLine($"Requesting {url}");
                var response = await httpClient.GetAsync(url);
                Console.WriteLine($"Response status code: {response.StatusCode}");
            }
        }
    }
}
