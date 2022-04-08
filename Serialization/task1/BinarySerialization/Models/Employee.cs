using System;

namespace BinarySerialization.Models
{
    [Serializable]
    public class Employee
    {
        public string EmployeeName { get; set; }

        public override string ToString()
        {
            return this.EmployeeName;
        }
    }
}