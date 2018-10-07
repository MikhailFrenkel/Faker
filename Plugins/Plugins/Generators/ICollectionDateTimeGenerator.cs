using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Interface;

namespace Generators
{
    public class ICollectionDateTimeGenerator : BaseGenerator, IGenerator
    {
        public Type Type { get; } = typeof(ICollection<DateTime>);

        public object GetValue()
        {
            return new Collection<DateTime>() {GetDateTime(), GetDateTime()};
        }
    }
}
