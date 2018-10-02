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
        private object _nestedObject;
        private IRandom _rnd;

        public Faker(IRandom rnd)
        {
            //TODO: exception в конструкторе?
            if (rnd == null)
                new ArgumentException("IRandom require notNull value");
            _rnd = rnd;
        }


        public T Create<T>() where T : new()
        {
            var ctors = typeof(T).GetConstructors().OrderByDescending(x => x.GetParameters().Length);
            var ctor = ctors.First();

            var parametersInfo = ctor.GetParameters();
            var parameters = new object[parametersInfo.Length];

            for (int i = 0; i < parametersInfo.Length; i++)
            {
                parameters[i] = GetValue(parametersInfo[i].ParameterType);
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

        private  T Init<T>(object o) where T: new()
        {
            _nestedObject = o;


            var ctors = typeof(T).GetConstructors().OrderByDescending(x => x.GetParameters().Length);
            var ctor = ctors.First();

            var parametersInfo = ctor.GetParameters();
            var parameters = new object[parametersInfo.Length];

            for (int i = 0; i < parametersInfo.Length; i++)
            {
                parameters[i] = GetValue(parametersInfo[i].ParameterType);
            }

            var result = ctor.Invoke(parameters);

            foreach (var property in typeof(T).GetProperties())
            {
                if (property?.SetMethod != null)
                {
                    if (property.SetMethod.IsPublic)
                    {
                        SetValue(ref result, property);

                        //property.SetMethod.Invoke(result, new[] {GetValue(property.PropertyType)});
                    }
                }
            }

            return (T)result;
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
                        property.SetMethod.Invoke(result, new[] {_nestedObject});
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
                    break;
            }
        }

        private void SetDateTime<T>(ref T result, PropertyInfo property)
        {
            var set = new object[] { _rnd.GetDateTime()};
            property.SetMethod.Invoke(result, set);
        }

        private void SetInt32<T>(ref T result, PropertyInfo property)
        {
            try
            {
                var set = new object[] {_rnd.GetInt32()};
                property.SetMethod.Invoke(result, set);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void SetString<T>(ref T result, PropertyInfo property)
        {
            var set = new object[] {_rnd.GetString()};
            property.SetMethod.Invoke(result, set);
        }

        private void SetInt64<T>(ref T result, PropertyInfo property)
        {
            var set = new object[] {_rnd.GetInt64()};
            property.SetMethod.Invoke(result, set);
        }

        private void SetDouble<T>(ref T result, PropertyInfo property)
        {
            var set = new object[] { _rnd.GetDouble() };
            property.SetMethod.Invoke(result, set);
        }

        private void SetSingle<T>(ref T result, PropertyInfo property)
        {
            var set = new object[] {_rnd.GetSingle()};
            property.SetMethod.Invoke(result, set);
        }     

        private object GetDTO<T>(ref T result, Type property)
        {
            try
            {
                var method =
                    typeof(Faker).GetMethod("Init", BindingFlags.Instance | BindingFlags.NonPublic);
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
            for (int i = 0; i < _rnd.GetPositiveValue(1, 20); i++)
            {
                col.Add(_rnd.GetInt32());
            }

            property.SetMethod.Invoke(result, new object[] {col});
        }

        private void SetICollectionInt64<T>(ref T result, PropertyInfo property)
        {
            ICollection<Int64> col = new Collection<Int64>();
            for (int i = 0; i < _rnd.GetPositiveValue(1, 20); i++)
            {
                col.Add(_rnd.GetInt64());
            }

            property.SetMethod.Invoke(result, new object[] { col });
        }

        private void SetICollectionString<T>(ref T result, PropertyInfo property)
        {
            ICollection<String> col = new Collection<String>();
            for (int i = 0; i < _rnd.GetPositiveValue(1, 20); i++)
            {
                col.Add(_rnd.GetString());
            }

            property.SetMethod.Invoke(result, new object[] { col });
        }

        private void SetICollectionDateTime<T>(ref T result, PropertyInfo property)
        {
            ICollection<DateTime> col = new Collection<DateTime>();
            for (int i = 0; i < _rnd.GetPositiveValue(1, 20); i++)
            {
                col.Add(_rnd.GetDateTime());
            }

            property.SetMethod.Invoke(result, new object[] { col });
        }

        private void SetICollectionDouble<T>(ref T result, PropertyInfo property)
        {
            ICollection<Double> col = new Collection<Double>();
            for (int i = 0; i < _rnd.GetPositiveValue(1, 20); i++)
            {
                col.Add(_rnd.GetDouble());
            }

            property.SetMethod.Invoke(result, new object[] { col });
        }

        private void SetICollectionSingle<T>(ref T result, PropertyInfo property)
        {
            ICollection<Single> col = new Collection<Single>();
            for (int i = 0; i < _rnd.GetPositiveValue(1, 20); i++)
            {
                col.Add(_rnd.GetSingle());
            }

            property.SetMethod.Invoke(result, new object[] { col });
        }

        private object GetValue(Type t)
        {
            switch (t.Name)
            {
                case "Int32":
                    return _rnd.GetInt32();
                case "Int64":
                    return _rnd.GetInt64();
                case "String":
                    return _rnd.GetString();
                case "Double":
                    return _rnd.GetDouble();
                case "Single":
                    return _rnd.GetSingle();
                case "DateTime":
                    return _rnd.GetDateTime();
                default:
                    return default(object);
            }
        }
    }
}
