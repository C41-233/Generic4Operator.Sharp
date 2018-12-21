using System;
using Generic4Operator.Factory;

namespace Generic4Operator.Operator
{
    internal static class UnaryPlus<T, R>
    {

        internal static readonly Func<T, R> Invoke;

        static UnaryPlus()
        {
            Invoke = OperatorFactory.CreateDelegate<Func<T, R>>("op_UnaryPlus");
            if (Invoke != null)
            {
                return;
            }
            if (typeof(T) == typeof(R))
            {
                Invoke = (Func<T, R>)(object)(Func<T, T>)(val => val);
            }
            else
            {
                Invoke = Throw.Func<T, R>;
            }
        }

    }

}
