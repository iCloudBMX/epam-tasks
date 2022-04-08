using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace JsonSerialization.Models
{
    [Serializable]
    public class Department
    {
        [JsonProperty("department")]
        public string DepartmentName { get; set; }

        [JsonProperty("employees")]
        public List<Employee> Employees { get; set; }

        public override string ToString()
        {
            return $"DepartmentName: {this.DepartmentName}" + Environment.NewLine +
                $"Employees: {string.Join(", ", this.Employees)}";
        }
    }
}