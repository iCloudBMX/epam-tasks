using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Listener
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StatusCodeListener(new[] { "http://localhost:8888/" });
        }

        static void StatusCodeListener(string[] prefixes)
        {
            if (prefixes is null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");

            using HttpListener httpListener = new HttpListener();

            foreach (string prefix in prefixes)
            {
                httpListener.Prefixes.Add(prefix);
            }
            httpListener.Start();

            Console.WriteLine("Server is listening its clients");

            while (true)
            {
                HttpListenerContext context = httpListener.GetContext();
                Console.WriteLine("Client connected");

                using (var response = context.Response)
                {
                    string absolutePath = context.Request.Url.AbsolutePath;

                    if (absolutePath == "/MyNameByHeader")
                    {
                        GetMyNameByHeader(response);
                    }
                }
            }
        }
        
        static void GetMyNameByHeader(HttpListenerResponse httpListenerResponse)
        {
            httpListenerResponse.AddHeader("X-MyName", GetMyName());
            httpListenerResponse.Close();
        }

        static string GetMyName() => "Xondamir";
    }
}
