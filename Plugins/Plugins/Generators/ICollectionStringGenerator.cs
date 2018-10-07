using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Interface;

namespace Generators
{
    public class ICollectionStringGenerator : BaseGenerator, IGenerator
    {
        public Type Type { get; } = typeof(ICollection<string>);

        public object GetValue()
        {
            return new Collection<string>() {GetString(), GetString()};
        }
    }
}
