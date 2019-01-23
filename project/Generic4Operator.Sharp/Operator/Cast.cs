using System;
using System.Linq.Expressions;
using Generic4Operator.Factory;

namespace Generic4Operator.Operator
{

    internal static class Cast<T, R>
    {

        internal static readonly Func<T, R> Invoke;

        static Cast()
        {
            var parameter = Expression.Parameter(typeof(T));
            try
            {
                Invoke = Expression.Lambda<Func<T, R>>(
                    Expression.Convert(parameter, typeof(R)),
                    parameter
                ).Compile();
            }
            catch (InvalidOperationException)
            {
                Invoke = Invoke ?? Throw.Func<T, R>;
            }

        }

    }

}
