using System;
using System.Text;
using Interface;

namespace CustomRandom1
{
    public class CustomRandom1
    {
        private readonly Random _rnd = new Random((int)DateTime.Now.Ticks);

        public Int32 GetInt32()
        {
            return _rnd.Next();
        }

        public string GetString(int size = 20)
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

        public DateTime GetDateTime()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(_rnd.Next(range));
        }

        public Int64 GetInt64()
        {
            return (Int64)(_rnd.Next() * _rnd.Next());
        }

        public Double GetDouble()
        {
            return _rnd.NextDouble();
        }

        public Single GetSingle()
        {
            return (float)_rnd.NextDouble();
        }

        public Int32 GetPositiveValue(int min, int max)
        {
            return Math.Abs(_rnd.Next(min, max));
        }
    }
}
