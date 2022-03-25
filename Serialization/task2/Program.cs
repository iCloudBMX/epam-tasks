using task2;

Person person =
    new Person(name: "Khondamir", age: 20);

BinarySerializer binarySerializer =
    new BinarySerializer(path: "person.bin");

Person deserializedPerson =
    binarySerializer.Deserialize();

Console.WriteLine(deserializedPerson);