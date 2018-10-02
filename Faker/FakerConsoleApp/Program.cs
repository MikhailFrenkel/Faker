using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FakerLibrary;
using Interface;

namespace FakerConsoleApp
{
    class Program
    {
        private const string Dll_1 = "../../../../Plugins/Plugins/CustomRandom1/bin/Debug/netstandard2.0/CustomRandom1.dll";
        private const string Dll_2 = "../../../../Plugins/Plugins/CustomRandom2/bin/Debug/netstandard2.0/CustomRandom2.dll";

        static void Main(string[] args)
        {
            IRandom rnd1 = GetCustomRandom(Dll_1);
            IRandom rnd_2 = GetCustomRandom(Dll_2);
            Faker faker = new Faker(rnd1);
            Bar bar = faker.Create<Bar>();
            Foo foo = faker.Create<Foo>();
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
