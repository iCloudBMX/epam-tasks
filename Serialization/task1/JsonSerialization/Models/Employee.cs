using Newtonsoft.Json;
using System;

namespace JsonSerialization.Models
{
    [Serializable]
    public class Employee
    {
        [JsonProperty("employeeName")]
        public string EmployeeName { get; set; }

        public override string ToString()
        {
            return this.EmployeeName;
        }
    }
}