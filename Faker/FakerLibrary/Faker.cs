using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using Interface;

namespace FakerLibrary
{
    public class Faker
    {
        private List<object> _nestedObjects;
        private Dictionary<Type, IGenerator> _generators;
        private const string Dll = "../../../../Plugins/Plugins/Generators/bin/Debug/netstandard2.0/Generators.dll";

        public Faker()
        {
            _nestedObjects = new List<object>();
            _generators = new Dictionary<Type, IGenerator>();
            GetGenerators(Dll);
        }

        public T Create<T>(object nested = null) where T : new()
        {
            if (nested != null)
                _nestedObjects.Add(nested);

            var ctors = typeof(T).GetConstructors().OrderByDescending(x => x.GetParameters().Length);
            var ctor = ctors.First();

            var parametersInfo = ctor.GetParameters();
            var parameters = new object[parametersInfo.Length];

            for (int i = 0; i < parametersInfo.Length; i++)
            {
                if (_generators.TryGetValue(parametersInfo[i].ParameterType, out var generator))
                    parameters[i] = generator.GetValue();
            }

            var result = ctor.Invoke(parameters);

            foreach (var property in typeof(T).GetProperties())
            {
                if (property?.SetMethod != null)
                {
                    if (property.SetMethod.IsPublic)
                    {
                        SetValue(ref result, property);
                    }
                }
            }

            return (T)result;
        }

        private void SetValue<T>(ref T result, PropertyInfo property)
        {
            var propertyType = property.PropertyType;
            string objectType = result.GetType().Name;

            if (_generators.TryGetValue(propertyType, out var generator))
                property.SetMethod.Invoke(result, new[] { generator.GetValue() } );
            else if (propertyType.Name == objectType)
            {
                property.SetMethod.Invoke(result, new object[] { result });
            }
            else if (_nestedObjects.Find(x => x.GetType() == propertyType) != null)
            {
                property.SetMethod.Invoke(result, new[] { _nestedObjects.Find(x => x.GetType() == propertyType) });
            }
            else
            {
                try
                {
                    property.SetMethod.Invoke(result, new[] { GetDTO(ref result, propertyType) });
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }

        private object GetDTO<T>(ref T result, Type property)
        {
            try
            {
                var method =
                    typeof(Faker).GetMethod("Create", BindingFlags.Instance | BindingFlags.Public);
                var genericMethod = method?.MakeGenericMethod(property);
                var dto = genericMethod?.Invoke(this, new object[] { result });
                return dto;
            }
            catch (Exception)
            {
                // ignored
            }

            return null;
        }

        private void GetGenerators(string pathDll)
        {
            var asm = Assembly.LoadFrom(pathDll);
            foreach (var type in asm.GetTypes())
            {
                if (type.GetInterface(typeof(IGenerator).FullName) != null)
                {
                    var gen = (IGenerator)Activator.CreateInstance(type);
                    _generators.Add(gen.Type, gen);
                }
            }
        }
    }
}
