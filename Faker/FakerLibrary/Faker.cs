using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Reflection;

namespace FakerLibrary
{
    public class Faker
    {
        public T Create<T>() where T : new()
        {
            Type type = typeof(T);
            T result = new T();
            
            foreach (var property in type.GetProperties())
            {
                if (property?.SetMethod != null)
                {
                    if (property.SetMethod.IsPublic)
                    {
                        var p = property.PropertyType;
                    }
                }
            }

            return result;
        }
    }
}
