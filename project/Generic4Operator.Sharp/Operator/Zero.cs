using System;
using Generic4Operator.Factory;

namespace Generic4Operator.Operator
{
    internal static class Zero<T>
    {

        internal static readonly Func<T> Invoke;

        static Zero()
        {
            OperatorFactory.TryBind(ref Invoke, () => (byte)0);
            OperatorFactory.TryBind(ref Invoke, () => (sbyte)0);
            OperatorFactory.TryBind(ref Invoke, () => (short)0);
            OperatorFactory.TryBind(ref Invoke, () => (ushort)0);
            OperatorFactory.TryBind(ref Invoke, () => 0);
            OperatorFactory.TryBind(ref Invoke, () => 0U);
            OperatorFactory.TryBind(ref Invoke, () => 0L);
            OperatorFactory.TryBind(ref Invoke, () => 0UL);
            OperatorFactory.TryBind(ref Invoke, () => 0F);
            OperatorFactory.TryBind(ref Invoke, () => 0D);
            OperatorFactory.TryBind(ref Invoke, () => false);
            OperatorFactory.TryBind(ref Invoke, () => (char)0);
            OperatorFactory.TryBind(ref Invoke, () => "");

            Invoke = Invoke ?? (() => default(T));
        }
    }
}
