using System;
using System.Text;
using Interface;

namespace Generators
{
    public class StringGenerator : BaseGenerator, IGenerator
    {
        public Type Type { get; } = typeof(String);

        public object GetValue()
        {
            return GetString();
        }
    }
}
