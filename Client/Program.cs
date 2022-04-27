using System;
using System.Net;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NameParserListener(new[] { "http://localhost:8888/" });
        }

        static void NameParserListener(string[] prefixes)
        {
            if(prefixes is null || prefixes.Length == 0)
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
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                Console.WriteLine("Client connected");

                if (context.Request.Url.AbsolutePath == "/MyName")
                {
                    string responseString = GetName();

                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

                    response.ContentLength64 = buffer.Length;
                    System.IO.Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    output.Close();
                }
                else
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Close();
                }
            }
        }

        static string GetName() => "Xondamir";
    }
}
