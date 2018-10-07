using System;
using Interface;

namespace Generators
{
    public class Int32Generator : BaseGenerator, IGenerator
    {
        public Type Type { get; } = typeof(Int32);

        public object GetValue()
        {
            return Rnd.Next();
        }
    }
}
