using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Test
{
    public class AnotherModel
    {
        public int Id { get; }

        public string Name { get; set; }

        public DateTime DateTime { get; }

        public AnotherModel()
        {
        }

        public AnotherModel(int id, DateTime dateTime)
        {
            Id = id;
            DateTime = dateTime;
        }

        public ThirdModel ThirdModel { get; set; }
    }
}
