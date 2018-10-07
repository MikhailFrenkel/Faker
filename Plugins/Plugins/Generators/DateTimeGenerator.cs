using System;
using Interface;

namespace Generators
{
    public class DateTimeGenerator : BaseGenerator, IGenerator
    {
        public Type Type { get; } = typeof(DateTime);

        public object GetValue()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(Rnd.Next(range));
        }
    }
}
