using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StatusCodeListener(new[] { "http://localhost:8888/" });
        }

        static void StatusCodeListener(string[] prefixes)
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
                Console.WriteLine("Client connected");

                using(var response = context.Response)
                {
                    string absolutePath = context.Request.Url.AbsolutePath;

                    if (absolutePath == "/Information")
                        response.StatusCode = (int)HttpStatusCode.Continue;
                    else if (absolutePath == "/Success")
                        response.StatusCode = (int)HttpStatusCode.OK;
                    else if (absolutePath == "/Redirection")
                        response.StatusCode = (int)HttpStatusCode.Redirect;
                    else if (absolutePath == "/ClientError")
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                    else if (absolutePath == "/ServerError")
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    response.Close();
                }
            }
        }
    }
}
