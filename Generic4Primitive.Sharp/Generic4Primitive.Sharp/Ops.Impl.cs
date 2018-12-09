using System;

namespace Generic4Primitive
{

    internal static class Ops<T> where T : struct
    {

        static Ops()
        {
            if (typeof(T) != typeof(byte)
                && typeof(T) != typeof(sbyte)
                && typeof(T) != typeof(char)
                && typeof(T) != typeof(short)
                && typeof(T) != typeof(ushort)
                && typeof(T) != typeof(int)
                && typeof(T) != typeof(uint)
                && typeof(T) != typeof(long)
                && typeof(T) != typeof(ulong)
                && typeof(T) != typeof(float)
                && typeof(T) != typeof(double)
                && typeof(T) != typeof(decimal)
            )
            {
                throw new NotSupportedException(typeof(T).ToString());
            }
        }

        public static Func<T, T, T> Add;

        public static Func<T, T, int> AddToInt;

        public static Func<T, T, T> Subtract;

        public static Func<T, T, int> SubtractToInt;

        public static IncreaseDelegate<T> Increase;

        public static IncreaseDelegate<T> IncreaseAndGetOriginal;

    }

    internal delegate T IncreaseDelegate<T>(ref T value);

}
