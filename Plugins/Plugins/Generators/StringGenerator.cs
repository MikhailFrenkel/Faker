using System;
using System.Text;
using Interface;

namespace Generators
{
    public class StringGenerator : BaseGenerator, IGenerator
    {
        public Type Type { get; } = typeof(String);

        public object GetValue()
        {
            int size = 20;

            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * Rnd.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
    }
}
