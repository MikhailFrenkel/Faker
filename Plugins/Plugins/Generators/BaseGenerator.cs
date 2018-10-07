using System;

namespace Generators
{
    public abstract class BaseGenerator
    {
        protected readonly Random Rnd = new Random((int)DateTime.Now.Ticks);
    }
}
