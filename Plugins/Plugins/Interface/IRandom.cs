using System;

namespace Interface
{
    public interface IRandom
    {
        Int32 GetInt32();
        string GetString(int size = 20);
        DateTime GetDateTime();
        Int64 GetInt64();
        Double GetDouble();
        Single GetSingle();
        Int32 GetPositiveValue(int min, int max);
    }
}
