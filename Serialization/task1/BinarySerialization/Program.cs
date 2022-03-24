using SerializerService.Serivces;
using SerializerService.Models.Seeds;
using SerializerService.Models;

Department department = SeedDepartment.GetDepartment();

var binarySerializer = new BinarySerializer("department.bin");

var deserializedDepartment = binarySerializer.Deserialize();

Console.WriteLine(deserializedDepartment);