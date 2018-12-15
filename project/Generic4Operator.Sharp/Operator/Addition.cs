using System;
using Generic4Operator.Factory;

namespace Generic4Operator.Operator
{

    internal static class Addition<T1, T2, R>
    {

        internal static readonly Func<T1, T2, R> Invoke;

        static Addition()
        {
            OperatorFactory.TryBind(ref Invoke, (byte a, byte b) => (byte)(a + b));
            OperatorFactory.TryBind(ref Invoke, (byte a, byte b) => a + b);

            OperatorFactory.TryBind(ref Invoke, (sbyte a, sbyte b) => (sbyte)(a + b));
            OperatorFactory.TryBind(ref Invoke, (sbyte a, sbyte b) => a + b);

            OperatorFactory.TryBind(ref Invoke, (short a, short b) => (short)(a + b));
            OperatorFactory.TryBind(ref Invoke, (short a, short b) => a + b);

            OperatorFactory.TryBind(ref Invoke, (ushort a, ushort b) => (ushort)(a + b));
            OperatorFactory.TryBind(ref Invoke, (ushort a, ushort b) => a + b);

            OperatorFactory.TryBind(ref Invoke, (int a, int b) => a + b);

            OperatorFactory.TryBind(ref Invoke, (uint a, uint b) => a + b);

            OperatorFactory.TryBind(ref Invoke, (long a, long b) => a + b);

            OperatorFactory.TryBind(ref Invoke, (ulong a, ulong b) => a + b);

            OperatorFactory.TryBind(ref Invoke, (float a, float b) => a + b);

            OperatorFactory.TryBind(ref Invoke, (double a, double b) => a + b);

            OperatorFactory.TryBind(ref Invoke, (bool a, bool b) => a || b);

            OperatorFactory.TryBind(ref Invoke, (char a, char b) => (char)(a + b));
            OperatorFactory.TryBind(ref Invoke, (char a, char b) => a + b);

            OperatorFactory.TryBind(ref Invoke, (string a, string b) => a + b);

            Invoke = Invoke 
                ?? OperatorFactory.CreateDelegate<Func<T1, T2, R>>("op_Addition") 
                ?? Throw.Value<T1, T2, R>;
        }

    }

}
