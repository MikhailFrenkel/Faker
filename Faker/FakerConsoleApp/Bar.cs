using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FakerConsoleApp
{
    public class Bar
    {
        public Bar()
        {
        }

        public Bar(int Id, string Name)
        {

        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<DateTime> Dates { get; set; }

        public Bar I { get; set; }

        public Foo Foo { get; set; }

        public Url Url { get; set; }
    }
}
