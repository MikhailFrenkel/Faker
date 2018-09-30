using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerConsoleApp
{
    public class Bar
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<DateTime> Dates { get; set; }

        public Bar I { get; set; }

        public Foo Foo { get; set; }
    }
}
