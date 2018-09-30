﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FakerLibrary
{
    internal static class CustomRandom
    {
        private static readonly Random Rnd = new Random((int)DateTime.Now.Ticks);

        internal static Int32 GetInt32()
        {
            return Rnd.Next();
        }

        internal static string GetString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * Rnd.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        internal static DateTime GetDateTime()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(Rnd.Next(range));
        }

        internal static Int64 GetInt64()
        {
            return (Int64)(Rnd.Next() * Rnd.Next());
        }

        internal static Double GetDouble()
        {
            return Rnd.NextDouble();
        }

        internal static Single GetSingle()
        {
            return (float) Rnd.NextDouble();
        }
    }
}