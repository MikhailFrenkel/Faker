using System;
using System.Collections.Generic;
using System.Text;
using Interface;

namespace Generators
{
    public class DateTimeGenerator : BaseGenerator, IGenerator
    {
        public Type Type { get; } = typeof(DateTime);

        public object GetValue()
        {
            return GetDateTime();
        }
    }
}
