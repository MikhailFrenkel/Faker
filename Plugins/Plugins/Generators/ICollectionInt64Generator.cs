using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Interface;

namespace Generators
{
    public class ICollectionInt64Generator : BaseGenerator, IGenerator
    {
        public Type Type { get; } = typeof(ICollection<Int64>);

        public object GetValue()
        {
            return new Collection<Int64>() {GetInt64(), GetInt64()};
        }
    }
}
