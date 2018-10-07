using System;
using FakerLibrary;

namespace FakerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Faker faker = new Faker();
            Bar bar = faker.Create<Bar>();
            Foo foo = faker.Create<Foo>();
            OutputProperties(bar);
            Console.ReadKey();
        }

        private static void OutputProperties(object value)
        {
            Console.WriteLine("Class: " + value.GetType().Name);
            foreach (var property in value.GetType().GetProperties())
            {
                if (property?.GetMethod != null)
                {
                    var propertyValue = property.GetValue(value);
                    Console.WriteLine(property.Name + ": " + propertyValue);
                    
                }
            }
            Console.WriteLine();
        }
    }
}
