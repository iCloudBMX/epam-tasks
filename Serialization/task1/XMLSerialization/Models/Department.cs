using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XMLSerialization.Models
{
    [Serializable]
    public class Department
    {
        [XmlElement(ElementName = "department")]
        public string DepartmentName { get; set; }
        
        [XmlElement(ElementName = "employees")]
        public List<Employee> Employees { get; set; }

        public override string ToString()
        {
            return $"DepartmentName: {this.DepartmentName}" + Environment.NewLine +
                $"Employees: {string.Join(", ", this.Employees)}";
        }
    }
}