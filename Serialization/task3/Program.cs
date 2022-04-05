using System;
using System.Collections.Generic;
using task3;

Department department = new Department
{
    DepartmentName = "IT",
    Employees = new List<Employee>
    {
        new Employee { EmployeeName = "Khondamir" },
        new Employee { EmployeeName = "Jonibek" }
    }
};

Department clonedDepartment = department.Clone();

if(ReferenceEquals(department, clonedDepartment))
    Console.WriteLine("Object is not cloned");
else
    Console.WriteLine("Object is cloned");