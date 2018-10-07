using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerConsoleApp
{
    public class Bro
    {
        public Bro()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<string> Topics { get; set; }

        public Bar Bar { get; set; }

        public Foo Foo { get; set; }
    }
}
