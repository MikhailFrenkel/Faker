using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Test
{
    public class ThirdModel
    {
        public ThirdModel()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public TestModel TestModel { get; set; }
    }
}
