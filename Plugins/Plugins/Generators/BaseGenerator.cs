using System;
using System.Text;

namespace Generators
{
    public abstract class BaseGenerator
    {
        private readonly Random _rnd = new Random((int)DateTime.Now.Ticks);

        protected Int32 GetInt32()
        {
            return _rnd.Next();
        }

        protected string GetString(int size = 20)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * _rnd.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        protected DateTime GetDateTime()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(_rnd.Next(range));
        }

        protected Int64 GetInt64()
        {
            return (Int64)(_rnd.Next() * _rnd.Next());
        }

        protected Double GetDouble()
        {
            return _rnd.NextDouble();
        }

        protected Single GetSingle()
        {
            return (float)_rnd.NextDouble();
        }

    }
}
