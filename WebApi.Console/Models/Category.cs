using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebApi.Console.Models
{
    public class Category
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; }
    }
}
