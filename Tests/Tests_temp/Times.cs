using System;

namespace ClioSDK.Tests
{
    public static class Times
    {
        public static TimeSpan Once => TimeSpan.FromMinutes(1);
        public static int Exactly(int count) => count;
    }
}