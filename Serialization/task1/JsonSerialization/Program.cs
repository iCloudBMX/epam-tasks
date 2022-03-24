using SerializerService.Serivces;
using SerializerService.Models.Seeds;
using SerializerService.Models;

Department department = SeedDepartment.GetDepartment();

var jsonSerializer = new JsonSerializer("department.json");

var deserializedDepartment = jsonSerializer.Deserialize();

Console.WriteLine(deserializedDepartment);