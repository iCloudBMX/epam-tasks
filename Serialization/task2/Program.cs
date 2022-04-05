using System;
using task2;

Person person =
    new Person(name: "Khondamir", age: 20);

BinarySerializer binarySerializer =
    new BinarySerializer(path: "person.bin");

binarySerializer.Serialize(person);

Person deserializedPerson =
    binarySerializer.Deserialize();

Console.WriteLine(deserializedPerson);