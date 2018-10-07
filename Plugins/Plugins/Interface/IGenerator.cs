using System;

namespace Interface
{
    public interface IGenerator
    {
        Type Type { get; }
        object GetValue();
    }
}
