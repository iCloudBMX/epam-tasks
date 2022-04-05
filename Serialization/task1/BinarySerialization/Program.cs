using SerializerService.Serivces;
using SerializerService.Models.Seeds;
using SerializerService.Models;
using System;

Department department = SeedDepartment.GetDepartment();

var binarySerializer = new BinarySerializer("department.bin");

binarySerializer.Serialize(department);

var deserializedDepartment = binarySerializer.Deserialize();

Console.WriteLine(deserializedDepartment);