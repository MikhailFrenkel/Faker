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

        public Int64 Number { get; set; }

        public ICollection<Int32> Numbers32 { get; set; }

        public ICollection<Int64> Numbers64 { get; set; }

        public DateTime Date { get; set; }

        public Bar I { get; set; }

        public Foo Foo { get; set; }

        public Url Url { get; set; }

        private int p;

        private string s { get; set; }
    }
}
