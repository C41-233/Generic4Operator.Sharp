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
                OperatorFactory.TryBind(ref Invoke, (int x, int y) => x / (float)y);

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
