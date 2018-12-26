using System;
using Generic4Operator.Factory;

namespace Generic4Operator.Operator
{
    internal static class Division<T1, T2, R>
    {
        internal static readonly Func<T1, T2, R> Invoke;

        static Division()
        {
            OperatorFactory.TryBind(ref Invoke, (byte a, byte b) => (byte)(a / b));
            OperatorFactory.TryBind(ref Invoke, (byte a, byte b) => a / b);
            OperatorFactory.TryBind(ref Invoke, (byte a, byte b) => a/ (float)b);
            OperatorFactory.TryBind(ref Invoke, (byte a, byte b) => a / (double)b);

            OperatorFactory.TryBind(ref Invoke, (sbyte a, sbyte b) => (sbyte)(a / b));
            OperatorFactory.TryBind(ref Invoke, (sbyte a, sbyte b) => a / b);
            OperatorFactory.TryBind(ref Invoke, (sbyte a, sbyte b) => a / (float)b);
            OperatorFactory.TryBind(ref Invoke, (sbyte a, sbyte b) => a / (double)b);

            OperatorFactory.TryBind(ref Invoke, (short a, short b) => (short)(a / b));
            OperatorFactory.TryBind(ref Invoke, (short a, short b) => a / b);
            OperatorFactory.TryBind(ref Invoke, (short a, short b) => a / (float)b);
            OperatorFactory.TryBind(ref Invoke, (short a, short b) => a / (double)b);

            OperatorFactory.TryBind(ref Invoke, (ushort a, ushort b) => (ushort)(a / b));
            OperatorFactory.TryBind(ref Invoke, (ushort a, ushort b) => a / b);
            OperatorFactory.TryBind(ref Invoke, (ushort a, ushort b) => a / (float)b);
            OperatorFactory.TryBind(ref Invoke, (ushort a, ushort b) => a / (double)b);

            OperatorFactory.TryBind(ref Invoke, (int a, int b) => a / b);
            OperatorFactory.TryBind(ref Invoke, (int a, int b) => a / (float)b);
            OperatorFactory.TryBind(ref Invoke, (int a, int b) => a / (double)b);

            OperatorFactory.TryBind(ref Invoke, (uint a, uint b) => a / b);
            OperatorFactory.TryBind(ref Invoke, (uint a, uint b) => a / (float)b);
            OperatorFactory.TryBind(ref Invoke, (uint a, uint b) => a / (double)b);

            OperatorFactory.TryBind(ref Invoke, (long a, long b) => a / b);
            OperatorFactory.TryBind(ref Invoke, (long a, long b) => a / (float)b);
            OperatorFactory.TryBind(ref Invoke, (long a, long b) => a / (double)b);

            OperatorFactory.TryBind(ref Invoke, (ulong a, ulong b) => a / b);
            OperatorFactory.TryBind(ref Invoke, (ulong a, ulong b) => a / (float)b);
            OperatorFactory.TryBind(ref Invoke, (ulong a, ulong b) => a / (double)b);

            OperatorFactory.TryBind(ref Invoke, (float a, float b) => a / b);
            OperatorFactory.TryBind(ref Invoke, (float a, float b) => a / (double) b);

            OperatorFactory.TryBind(ref Invoke, (double a, double b) => a / b);
            OperatorFactory.TryBind(ref Invoke, (double a, double b) => (float)(a / b));

            OperatorFactory.TryBind(ref Invoke, (char a, char b) => (char)(a / b));
            OperatorFactory.TryBind(ref Invoke, (char a, char b) => a / b);
            OperatorFactory.TryBind(ref Invoke, (char a, char b) => a / (float) b);
            OperatorFactory.TryBind(ref Invoke, (char a, char b) => a / (double)b);

            Invoke = Invoke
                ?? OperatorFactory.CreateDelegate<Func<T1, T2, R>>("op_Division")
                ?? Throw.Func<T1, T2, R>;
        }

    }

}
