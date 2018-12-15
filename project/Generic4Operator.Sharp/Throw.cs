using System;

namespace Generic4Operator
{

    internal class Throw
    {

        internal static R Value<T, R>(T value)
        {
            throw new NotSupportedException();
        }

        internal static R Value<T1, T2, R>(T1 value1, T2 value2)
        {
            throw new NotSupportedException();
        }

    }

}
