using System.Collections.Generic;

namespace XMLSerialization.Models.Seeds
{
    public class SeedDepartment
    {
        public static Department GetDepartment()
        {
            return new Department
            {
                DepartmentName = "IT",
                Employees = new List<Employee>
                {
                    new Employee { EmployeeName = "Khondamir" },
                    new Employee { EmployeeName = "Jonibek" }
                }
            };
        }
    }
}