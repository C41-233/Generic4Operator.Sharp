using System;
using System.Linq.Expressions;
using Generic4Operator.Factory;

namespace Generic4Operator.Operator
{

    internal static class DivisionTable
    {

        internal static readonly BinaryOperatorFactory Factory = new BinaryOperatorFactory("op_Division", Expression.Divide);

        static DivisionTable()
        {
            Factory.RegisterPrimitive((int x, int y) => x / y);
            Factory.RegisterPrimitive<int, float, int, float, float>();

            Factory.RegisterPrimitive((long x, long y) => x / y);
            Factory.RegisterPrimitive<long, double, long, double, double>();
        }
    }

    internal static class Division<T1, T2, R>
    {
        internal static readonly Func<T1, T2, R> Invoke;
        internal static readonly bool Supported;

        static Division()
        {
            try
            {
                Invoke = Invoke ?? DivisionTable.Factory.CreateDelegate<T1, T2, R>();
            }
            finally
            {
                Supported = Invoke != null;
                Invoke = Invoke ?? Throw.Func<T1, T2, R>;
            }
        }

    }

}
