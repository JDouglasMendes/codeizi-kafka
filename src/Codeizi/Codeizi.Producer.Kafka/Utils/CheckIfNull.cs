using System;

namespace Codeizi.Producer.Kafka
{
    internal static class CheckIfNull
    {
        public static void Is<T>(this T value)
        {
            if (value == null)
                throw new ArgumentException($"The {typeof(T).FullName} is null");
        }
    }
}