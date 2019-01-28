using System;
using System.Linq.Expressions;
using Generic4Operator.Factory;

namespace Generic4Operator.Operator
{

    internal static class AdditionTable
    {

        internal static readonly BinaryOperatorFactory Factory = new BinaryOperatorFactory("op_Addition", Expression.Add);

        static AdditionTable()
        {
            Factory.RegisterPrimitive((byte a, byte b) => a + b);

            Factory.RegisterPrimitive((int a, int b) => a + b);

            Factory.RegisterPrimitive((int a, uint b) => a + b);
            Factory.RegisterPrimitive((uint a, int b) => a + b);

            Factory.RegisterPrimitive((int a, long b) => a + b);
            Factory.RegisterPrimitive((long a, int b) => a + b);

            Factory.RegisterPrimitive((int a, float b) => a + b);
            Factory.RegisterPrimitive((float a, float b) => a + b);
        }
    }

    internal static class Addition<T1, T2, R>
    {

        internal static readonly Func<T1, T2, R> Invoke;
        internal static readonly bool Supported;

        static Addition()
        {
            try
            {
                OperatorFactory.TryBind(ref Invoke, (string a, string b) => a + b);
                OperatorFactory.TryBind(ref Invoke, (bool a, bool b) => a || b);

                if (Invoke != null)
                {
                    return;
                }

                Invoke = AdditionTable.Factory.CreateDelegate<T1, T2, R>();
            }
            finally
            {
                Supported = Invoke != null;
                Invoke = Invoke ?? Throw.Func<T1,T2,R>;
            }
        }

    }

}
