using SerializerService.Serivces;
using SerializerService.Models.Seeds;
using SerializerService.Models;

Department department = SeedDepartment.GetDepartment();

var xmlSerializer = new XMLSerializer("department.xml");

var deserializedDepartment = xmlSerializer.Deserialize();

Console.WriteLine(deserializedDepartment);