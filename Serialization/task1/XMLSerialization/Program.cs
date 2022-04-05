using SerializerService.Serivces;
using SerializerService.Models.Seeds;
using SerializerService.Models;
using System;

Department department = SeedDepartment.GetDepartment();

var xmlSerializer = new XMLSerializer("department.xml");

xmlSerializer.Serialize(department);

var deserializedDepartment = xmlSerializer.Deserialize();

Console.WriteLine(deserializedDepartment);