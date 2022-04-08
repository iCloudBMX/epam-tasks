using System;
using System.Xml.Serialization;

namespace XMLSerialization.Models
{
    [Serializable]
    public class Employee
    {
        [XmlElement(ElementName = "employeeName")]
        public string EmployeeName { get; set; }

        public override string ToString()
        {
            return this.EmployeeName;
        }
    }
}