using System;
using System.Reflection;

namespace FakerLibrary
{
    public class Faker
    {
        private const int MaxString = 20;

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
                        SetValue<T>(ref result, property);
                    }
                }
            }

            return result;
        }

        private void SetValue<T>(ref T result, PropertyInfo property)
        {
            var propertyType = property.PropertyType;
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
            var set = new object[] {CustomRandom.GetString(MaxString)};
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
    }
}
