using System;
using System.Linq.Expressions;
using Generic4Operator.Factory;

namespace Generic4Operator.Operator
{
    internal static class Decrement<T, R>
    {

        internal static readonly Func<T, R> Invoke;

        static Decrement()
        {
            OperatorFactory.TryBind(ref Invoke, (bool val) => false);

            if (Invoke != null)
            {
                return;
            }

            try
            {
                var parameter = Expression.Parameter(typeof(T));
                Invoke = Expression.Lambda<Func<T, R>>(
                    Expression.PreDecrementAssign(parameter),
                    parameter
                ).Compile();
            }
            catch (Exception)
            {
                Invoke = Throw.Func<T, R>;
            }
        }
    }
}
