using System;

namespace Generic4Operator.Factory
{

    internal class Throw
    {

        internal static R Func<T, R>(T value)
        {
            throw new NotSupportedException();
        }

        internal static R Func<T1, T2, R>(T1 value1, T2 value2)
        {
            throw new NotSupportedException();
        }

        internal static R Func<T1, T2, T3, R>(T1 value1, T2 value2, T3 value)
        {
            throw new NotSupportedException();
        }

        internal static void Action<T1, T2>(T1 value1, T2 value2)
        {
            throw new NotSupportedException();
        }

        internal static void Action<T1, T2, T3>(T1 value1, T2 value2, T3 value3)
        {
            throw new NotSupportedException();
        }

        internal static void Action<T1, T2, T3, T4>(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            throw new NotSupportedException();
        }

    }

}
