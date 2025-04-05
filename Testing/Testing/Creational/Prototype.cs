
using System;

namespace Testing.Creational
{
    // Prototype Interface
    public interface IPrototype<T>
    {
        T Clone();
    }

    // Concrete Prototype 1
    public class Person : IPrototype<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Person Clone()
        {
            return (Plerson)this.MemberwiseClone(); // Shallow copy
        }

        public override string ToString()
        {
            return $"Person: {Name}, Age: {age}";
        }
    }

    // Concrete Prototype 2
    public class Address : IPrototype<Address>
    {
        public string City { get; set; }

        public Address(string city)
        {
            City = city;
        }

        public Address Clone()
        {
            return new Address(this.City); // Deep copy-like behavior for simple objects
        }

        public override string ToString()
        {
            return $"Address: {City}";
        }
    }

    // Client code demo
    public class PrototypeDemo
    {
        public static void Run()
        {
            Console.WriteLine("===== Prototype Pattern Demo ======");

            var originalPerson = new Person("John Doe", 30);
            var clonedPerson = originalPerson.Clone();
            clonedPerson.Name = "Jane Doe"; // Modify clone

            Console.WriteLine("Original: " + originalPerson);
            Console.WriteLine("Clone:    " + clonedPerson);

            var originalAddress = new Address("New York");
            var clonedAddress = originalAddress.Clone();
            clonedAddress.City = "Los Angeles";

            Console.WriteLine("Original: " + originalAddress);
            Console.WriteLine("Clone:    " + clonedAddress);
        }
    }
}
