
using System;
using System.Linq.Expressions;
using System.Text;
using Generic4Operator.Factory;

namespace Generic4Operator.Operator
{

    internal static class MultiplyTable
    {
        
        internal static BinaryOperatorFactory Factory = new BinaryOperatorFactory("op_Multiply", Expression.Multiply);

        static MultiplyTable()
        {
            Factory.RegisterPrimitive((byte a, byte b) => a * b);

            Factory.RegisterPrimitive((sbyte a, sbyte b) => a * b);

            Factory.RegisterPrimitive((char a, char b) => a * b);

            Factory.RegisterPrimitive((short a, short b) => a * b);

            Factory.RegisterPrimitive((ushort a, ushort b) => a * b);

            Factory.RegisterPrimitive((int a, int b) => a * b);

            Factory.RegisterPrimitive((uint a, uint b) => a * b);

            Factory.RegisterPrimitive((long a, long b) => a * b);

            Factory.RegisterPrimitive((ulong a, ulong b) => a * b);

            Factory.RegisterPrimitive((float a, float b) => a * b);

            Factory.RegisterPrimitive((double a, double b) => a * b);
        }

    }

    internal static class Multiply<T1, T2, R>
    {

        internal static readonly Func<T1, T2, R> Invoke;
        internal static readonly bool Supported;

        static Multiply()
        {
            try
            {
                OperatorFactory.TryBind(ref Invoke, (bool a, bool b) => a && b);
                OperatorFactory.TryBind<T1, T2, R, string, int, string>(ref Invoke, Do_string_int);

                Invoke = Invoke ?? MultiplyTable.Factory.CreateDelegate<T1, T2, R>();
            }
            finally
            {
                Supported = Invoke != null;
                Invoke = Invoke ?? Throw.Func<T1, T2, R>;
            }
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
