using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Interface;

namespace Generators
{
    public class ICollectionDoubleGenerator : BaseGenerator, IGenerator
    {
        public Type Type { get; } = typeof(ICollection<Double>);

        public object GetValue()
        {
            return new Collection<Double>() { GetDouble(), GetDouble()};
        }
    }
}
