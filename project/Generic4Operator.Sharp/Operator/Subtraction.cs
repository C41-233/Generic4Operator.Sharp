using System;
using System.Linq.Expressions;
using Generic4Operator.Factory;

namespace Generic4Operator.Operator
{

    internal static class SubtractionTable
    {
        
        internal static readonly BinaryOperatorFactory Factory = new BinaryOperatorFactory("op_Subtraction", Expression.Subtract);

        static SubtractionTable()
        {
            Factory.RegisterPrimitive((byte a, byte b) => a - b);

            Factory.RegisterPrimitive((char a, char b) => a - b);

            Factory.RegisterPrimitive((sbyte a, sbyte b) => a - b);

            Factory.RegisterPrimitive((short a, short b) => a - b);

            Factory.RegisterPrimitive((ushort a, ushort b) => a - b);

            Factory.RegisterPrimitive((int a, int b) => a - b);

            Factory.RegisterPrimitive((uint a, uint b) => a - b);

            Factory.RegisterPrimitive((long a, long b) => a - b);

            Factory.RegisterPrimitive((ulong a, ulong b) => a - b);

            Factory.RegisterPrimitive((float a, float b) => a - b);

            Factory.RegisterPrimitive((double a, double b) => a - b);
        }

    }

    internal static class Subtraction<T1, T2, R>
    {

        internal static readonly Func<T1, T2, R> Invoke;
        internal static readonly bool Supported;

        static Subtraction()
        {
            try
            {
                OperatorFactory.TryBind(ref Invoke, (bool a, bool b) => a && !b);

                if (Invoke != null)
                {
                    return;
                }

                Invoke = SubtractionTable.Factory.CreateDelegate<T1, T2, R>();
            }
            finally
            {
                Supported = Invoke != null;
                Invoke = Invoke ?? Throw.Func<T1, T2, R>;
            }
        }

    }

}
