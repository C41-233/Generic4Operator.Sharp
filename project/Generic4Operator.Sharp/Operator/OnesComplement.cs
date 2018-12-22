using System;
using Generic4Operator.Factory;

namespace Generic4Operator.Operator
{
    internal static class OnesComplement<T, R>
    {

        internal static readonly Func<T, R> Invoke;

        static OnesComplement()
        {
            OperatorFactory.TryBind(ref Invoke, (byte val) => ~val);
            OperatorFactory.TryBind(ref Invoke, (byte val) => (byte)~val);

            OperatorFactory.TryBind(ref Invoke, (sbyte val) => ~val);
            OperatorFactory.TryBind(ref Invoke, (sbyte val) => (sbyte)~val);

            OperatorFactory.TryBind(ref Invoke, (short val) => ~val);
            OperatorFactory.TryBind(ref Invoke, (short val) => (short)~val);

            OperatorFactory.TryBind(ref Invoke, (ushort val) => ~val);
            OperatorFactory.TryBind(ref Invoke, (ushort val) => (ushort)~val);

            OperatorFactory.TryBind(ref Invoke, (int val) => ~val);

            OperatorFactory.TryBind(ref Invoke, (uint val) => ~val);

            OperatorFactory.TryBind(ref Invoke, (long val) => ~val);

            OperatorFactory.TryBind(ref Invoke, (ulong val) => ~val);

            OperatorFactory.TryBind(ref Invoke, (char val) => ~val);
            OperatorFactory.TryBind(ref Invoke, (char val) => (char)~val);

            OperatorFactory.TryBind(ref Invoke, (bool val) => !val);

            Invoke = Invoke
                ?? OperatorFactory.CreateDelegate<Func<T, R>>("op_OnesComplement")
                ?? Throw.Func<T, R>;
        }


    }
}
