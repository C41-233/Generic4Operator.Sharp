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
            OperatorFactory.TryBind<T, R, T, T>(ref Invoke, val => val);
            Invoke = Invoke ?? Throw.Func<T, R>;
        }

    }

}
