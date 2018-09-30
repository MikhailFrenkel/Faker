using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace FakerLibrary
{
    public class Faker
    {
        private object _nestedObject;

        public T Create<T>() where T : new()
        {
            T result = new T();
            
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

            return result;
        }

        private  T Init<T>(object o) where T: new()
        {
            T result = new T();
            _nestedObject = o;

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

            return result;
        }

        private void SetValue<T>(ref T result, PropertyInfo property)
        {
            var propertyType = property.PropertyType;
            string objectType = result.GetType().Name;
            switch (propertyType.Name)
            {
                case "Int32":
                    SetInt32(ref result, property);
                    break;
                case "String":
                    SetString(ref result, property);
                    break;
                case "DateTime":
                    SetDateTime(ref result, property);
                    break;
                case "Int64":
                    SetInt64(ref result, property);
                    break;
                case "Double":
                    SetDouble(ref result, property);
                    break;
                case "Single":
                    SetSingle(ref result, property);
                    break;
                case "ICollection`1":
                    SetICollection(ref result, property);
                    break;
                default:
                    if (propertyType.Name == objectType)
                    {
                        property.SetMethod.Invoke(result, new object[] {result});
                    }
                    else if (propertyType.Name == _nestedObject?.GetType().Name)
                    {
                        property.SetMethod.Invoke(result, new object[] {_nestedObject});
                    }
                    else
                    {
                    var method = typeof(Faker).GetMethod("Init", BindingFlags.Instance | BindingFlags.NonPublic);
                        var genericMethod = method?.MakeGenericMethod(propertyType);
                        var set = genericMethod?.Invoke(this, new object[] {result});
                        property.SetMethod.Invoke(result, new[] {set});
                    }

                    break;
            }
        }

        private void SetDateTime<T>(ref T result, PropertyInfo property)
        {
            var set = new object[] { CustomRandom.GetDateTime()};
            property.SetMethod.Invoke(result, set);
        }

        private void SetInt32<T>(ref T result, PropertyInfo property)
        { 
            var set = new object[]{ CustomRandom.GetInt32() };
            property.SetMethod.Invoke(result, set);
        }

        private void SetString<T>(ref T result, PropertyInfo property)
        {
            var set = new object[] {CustomRandom.GetString()};
            property.SetMethod.Invoke(result, set);
        }

        private void SetInt64<T>(ref T result, PropertyInfo property)
        {
            var set = new object[] {CustomRandom.GetInt64()};
            property.SetMethod.Invoke(result, set);
        }

        private void SetDouble<T>(ref T result, PropertyInfo property)
        {
            var set = new object[] { CustomRandom.GetDouble() };
            property.SetMethod.Invoke(result, set);
        }

        private void SetSingle<T>(ref T result, PropertyInfo property)
        {
            var set = new object[] {CustomRandom.GetSingle()};
            property.SetMethod.Invoke(result, set);
        }

        private void SetICollection<T>(ref T result, PropertyInfo property)
        {
            var nestedType = property.PropertyType.GenericTypeArguments[0];

            switch (nestedType.Name)
            {
                case "Int32":
                    SetICollectionInt32(ref result, property);
                    break;
                case "String":
                    SetICollectionString(ref result, property);
                    break;
                case "DateTime":
                    SetICollectionDateTime(ref result, property);
                    break;
                case "Int64":
                    SetICollectionInt64(ref result, property);
                    break;
                case "Double":
                    SetICollectionDouble(ref result, property);
                    break;
                case "Single":
                    SetICollectionSingle(ref result, property);
                    break;
            }
        }

        private void SetICollectionInt32<T>(ref T result, PropertyInfo property)
        {
            ICollection<Int32> col = new Collection<Int32>();
            for (int i = 0; i < CustomRandom.GetPositiveValue(1, 20); i++)
            {
                col.Add(CustomRandom.GetInt32());
            }

            property.SetMethod.Invoke(result, new object[] {col});
        }

        private void SetICollectionInt64<T>(ref T result, PropertyInfo property)
        {
            ICollection<Int64> col = new Collection<Int64>();
            for (int i = 0; i < CustomRandom.GetPositiveValue(1, 20); i++)
            {
                col.Add(CustomRandom.GetInt64());
            }

            property.SetMethod.Invoke(result, new object[] { col });
        }

        private void SetICollectionString<T>(ref T result, PropertyInfo property)
        {
            ICollection<String> col = new Collection<String>();
            for (int i = 0; i < CustomRandom.GetPositiveValue(1, 20); i++)
            {
                col.Add(CustomRandom.GetString());
            }

            property.SetMethod.Invoke(result, new object[] { col });
        }

        private void SetICollectionDateTime<T>(ref T result, PropertyInfo property)
        {
            ICollection<DateTime> col = new Collection<DateTime>();
            for (int i = 0; i < CustomRandom.GetPositiveValue(1, 20); i++)
            {
                col.Add(CustomRandom.GetDateTime());
            }

            property.SetMethod.Invoke(result, new object[] { col });
        }

        private void SetICollectionDouble<T>(ref T result, PropertyInfo property)
        {
            ICollection<Double> col = new Collection<Double>();
            for (int i = 0; i < CustomRandom.GetPositiveValue(1, 20); i++)
            {
                col.Add(CustomRandom.GetDouble());
            }

            property.SetMethod.Invoke(result, new object[] { col });
        }

        private void SetICollectionSingle<T>(ref T result, PropertyInfo property)
        {
            ICollection<Single> col = new Collection<Single>();
            for (int i = 0; i < CustomRandom.GetPositiveValue(1, 20); i++)
            {
                col.Add(CustomRandom.GetSingle());
            }

            property.SetMethod.Invoke(result, new object[] { col });
        }
    }
}
