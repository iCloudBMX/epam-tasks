using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using WebApi.Console.Models;

namespace WebApi.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.ReadLine();
            
            string baseUrl = "https://localhost:44363/api/";
            
            using HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);

            // Get all products
            HttpResponseMessage response = httpClient.GetAsync("products").Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var products = JsonConvert.DeserializeObject<IList<Product>>(content);

                DisplayProducts(products);
            }
            else
            {
                System.Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            // Get all categories

            response = httpClient.GetAsync("categories").Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var categories = JsonConvert.DeserializeObject<IList<Category>>(content);

                DisplayCategories(categories);
            }
            else
            {
                System.Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        static void DisplayProducts(IEnumerable<Product> products)
        {
            foreach (var product in products)
                System.Console.WriteLine(product.Name);
        }

        static void DisplayCategories(IEnumerable<Category> categories)
        {
            foreach (var category in categories)
                System.Console.WriteLine(category.Name);
        }
    }
}
