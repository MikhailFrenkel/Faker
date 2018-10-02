using System;
using System.Text;
using Interface;

namespace CustomRandom2
{
    public class CustomRandom2 : IRandom
    {
        private Random _rnd = new Random((int)DateTime.Now.Ticks);

        public int GetInt32()
        {
            return _rnd.Next();
        }

        public string GetString(int size = 20)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * _rnd.NextDouble())));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        public DateTime GetDateTime()
        {
            DateTime start = new DateTime(2000, 10, 15);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(_rnd.Next(range));
        }

        public long GetInt64()
        {
            return (Int64)Math.Pow(_rnd.Next(), 3);
        }

        public double GetDouble()
        {
            return Math.Sqrt(Math.Pow(_rnd.NextDouble(), 3));
        }

        public float GetSingle()
        {
            return (float)Math.Sqrt(_rnd.Next());
        }

        public int GetPositiveValue(int min, int max)
        {
            return Math.Abs(_rnd.Next(min, max));
        }
    }
}
