using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Interface;

namespace Generators
{
    public class ICollectionInt32Generator : BaseGenerator, IGenerator
    {
        public Type Type { get; } = typeof(ICollection<Int32>);

        public object GetValue()
        {
            return new Collection<Int32> { GetInt32(), GetInt32()};
        }
    }
}
