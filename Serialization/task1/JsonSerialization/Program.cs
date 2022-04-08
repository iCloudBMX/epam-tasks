using JsonSerialization.Serivces;
using JsonSerialization.Models.Seeds;
using JsonSerialization.Models;
using System;

Department department = SeedDepartment.GetDepartment();

var jsonSerializer = new JsonSerializer("department.json");

jsonSerializer.Serialize(department);

var deserializedDepartment = jsonSerializer.Deserialize();

Console.WriteLine(deserializedDepartment);