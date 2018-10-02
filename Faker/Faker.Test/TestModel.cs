using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Test
{
    public class TestModel
    {
        public Int32 Id { get; set; }
        public Int64 Number { get; set; }
        public string Name { get; set; }
        public ICollection<DateTime> Dates { get; set; }
        public AnotherModel AnotherModel { get; set; }
    }
}
