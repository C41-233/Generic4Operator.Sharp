
using System;
using System.Text;
using Generic4Operator.Factory;

namespace Generic4Operator.Operator
{

    internal static class Multiply<T1, T2, R>
    {

        internal static readonly Func<T1, T2, R> Invoke;

        static Multiply()
        {
            OperatorFactory.TryBind(ref Invoke, (byte a, byte b) => (byte)(a * b));
            OperatorFactory.TryBind(ref Invoke, (byte a, byte b) => a * b);

            OperatorFactory.TryBind(ref Invoke, (sbyte a, sbyte b) => (sbyte)(a * b));
            OperatorFactory.TryBind(ref Invoke, (sbyte a, sbyte b) => a * b);

            OperatorFactory.TryBind(ref Invoke, (short a, short b) => (short)(a * b));
            OperatorFactory.TryBind(ref Invoke, (short a, short b) => a * b);

            OperatorFactory.TryBind(ref Invoke, (ushort a, ushort b) => (ushort)(a * b));
            OperatorFactory.TryBind(ref Invoke, (ushort a, ushort b) => a * b);

            OperatorFactory.TryBind(ref Invoke, (int a, int b) => a * b);
            OperatorFactory.TryBind(ref Invoke, (int a, int b) => (long)a * b);

            OperatorFactory.TryBind(ref Invoke, (uint a, uint b) => a * b);
            OperatorFactory.TryBind(ref Invoke, (uint a, uint b) => (ulong)a * b);
            OperatorFactory.TryBind(ref Invoke, (uint a, uint b) => (long)a * b);

            OperatorFactory.TryBind(ref Invoke, (long a, long b) => a * b);

            OperatorFactory.TryBind(ref Invoke, (ulong a, ulong b) => a * b);

            OperatorFactory.TryBind(ref Invoke, (float a, float b) => a * b);
            OperatorFactory.TryBind(ref Invoke, (float a, float b) => (double)a * b);

            OperatorFactory.TryBind(ref Invoke, (double a, double b) => a * b);

            OperatorFactory.TryBind(ref Invoke, (bool a, bool b) => a && b);

            OperatorFactory.TryBind(ref Invoke, (char a, char b) => (char)(a * b));
            OperatorFactory.TryBind(ref Invoke, (char a, char b) => a * b);

            OperatorFactory.TryBind<T1, T2, R, string, int, string>(ref Invoke, Do_string_int);

            Invoke = Invoke
                ?? OperatorFactory.CreateDelegate<Func<T1, T2, R>>("op_Multiply")
                ?? Throw.Func<T1, T2, R>;
        }

        private static string Do_string_int(string a, int b)
        {
            switch (b)
            {
                case 0:
                    return "";
                case 1:
                    return a;
                case 2:
                    return a + a;
                case 3:
                    return a + a + a;
            }
            if (b < 0)
            {
                throw new ArgumentException($"{a} * {b}");
            }
            var sb = new StringBuilder();
            for (var i = 0; i < b; i++)
            {
                sb.Append(a);
            }
            return sb.ToString();
        }

    }

}
