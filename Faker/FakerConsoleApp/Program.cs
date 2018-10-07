using System;
using System.Reflection;
using FakerLibrary;
using Interface;

namespace FakerConsoleApp
{
    class Program
    {
        //TODO: Dictionary<Type, Generator>

        private const string Dll_1 = "../../../../Plugins/Plugins/CustomRandom1/bin/Debug/netstandard2.0/CustomRandom1.dll";
        private const string Dll_2 = "../../../../Plugins/Plugins/CustomRandom2/bin/Debug/netstandard2.0/CustomRandom2.dll";

        static void Main(string[] args)
        {
            IRandom rnd1 = GetCustomRandom(Dll_1);
            IRandom rnd_2 = GetCustomRandom(Dll_2);
            Faker faker = new Faker(rnd1);
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

        private static IRandom GetCustomRandom(string pathDll)
        {
            var asm = Assembly.LoadFrom(pathDll);
            foreach (var type in asm.GetTypes())
            {
                if (type.GetInterface(typeof(IRandom).FullName) != null)
                {
                    return (IRandom) Activator.CreateInstance(type);
                }
            }

            return null;
        }
    }
}
