using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerConsoleApp
{
    class Foo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public long Ticks { get; set; }

        public double Cash { get; set; }

        public float Random { get; set; }

        public ICollection<int> Days { get; set; }

        public ICollection<DateTime> Dates { get; set; }
    }
}
