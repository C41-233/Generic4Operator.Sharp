using System;
using Generic4Operator.Factory;

namespace Generic4Operator.Operator
{

    internal static class Increment<T, R>
    {

        internal static readonly Func<T, R> Invoke;

        static Increment()
        {
            OperatorFactory.TryBind(ref Invoke, (byte val) => ++val);
            OperatorFactory.TryBind(ref Invoke, (sbyte val) => ++val);
            OperatorFactory.TryBind(ref Invoke, (short val) => ++val);
            OperatorFactory.TryBind(ref Invoke, (ushort val) => ++val);
            OperatorFactory.TryBind(ref Invoke, (int val) => ++val);
            OperatorFactory.TryBind(ref Invoke, (uint val) => ++val);
            OperatorFactory.TryBind(ref Invoke, (long val) => ++val);
            OperatorFactory.TryBind(ref Invoke, (ulong val) => ++val);
            OperatorFactory.TryBind(ref Invoke, (float val) => ++val);
            OperatorFactory.TryBind(ref Invoke, (double val) => ++val);
            OperatorFactory.TryBind(ref Invoke, (bool val) => true);
            OperatorFactory.TryBind(ref Invoke, (char val) => ++val);

            Invoke = Invoke
                ?? OperatorFactory.CreateDelegate<Func<T, R>>("op_Increment")
                ?? Throw.Func<T, R>;
        }
    }
}
