using System;
using System.Runtime.Serialization;

namespace task2
{
    [Serializable]
    public class Person : ISerializable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        { }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        
        /// <summary>
        /// The special constructor is used to deserialize values
        /// </summary>
        /// <param name="serializationInfo"></param>
        /// <param name="streamingContext"></param>
        public Person(
            SerializationInfo serializationInfo,
            StreamingContext streamingContext)
        {            
            this.Name = (string) serializationInfo.GetValue(
                name: "Name", 
                type: typeof(string));
        }

        /// <summary>
        /// This method is for serialize data
        /// The method is called on serialization
        /// </summary>
        /// <param name="serializationInfo"></param>
        /// <param name="streamingContext"></param>
        public void GetObjectData(
            SerializationInfo serializationInfo,
            StreamingContext streamingContext)
        {
            serializationInfo.AddValue("Name", this.Name);
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}