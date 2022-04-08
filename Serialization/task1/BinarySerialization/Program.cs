using BinarySerialization.Serivces;
using BinarySerialization.Models.Seeds;
using BinarySerialization.Models;
using System;

Department department = SeedDepartment.GetDepartment();

var binarySerializer = new BinarySerializer("department.bin");

binarySerializer.Serialize(department);

var deserializedDepartment = binarySerializer.Deserialize();

Console.WriteLine(deserializedDepartment);