using System;
using System.Collections.Generic;

namespace task3
{
    [Serializable]
    public class Department
    {
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; }

        public override string ToString()
        {
            return $"DepartmentName: {this.DepartmentName}" + Environment.NewLine +
                $"Employees: {string.Join(", ", this.Employees)}";
        }
    }
}