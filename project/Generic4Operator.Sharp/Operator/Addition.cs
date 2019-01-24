using System;
using System.Linq.Expressions;
using Generic4Operator.Factory;

namespace Generic4Operator.Operator
{

    internal static class Addition<T1, T2, R>
    {

        internal static readonly Func<T1, T2, R> Invoke;

        static Addition()
        {
            OperatorFactory.TryBind(ref Invoke, (bool a, bool b) => a || b);
            OperatorFactory.TryBind(ref Invoke, (string a, string b) => a + b);

            OperatorFactory.TryBind(ref Invoke, (int a, float b) => a + b);
            OperatorFactory.TryBind(ref Invoke, (int a, double b) => a + b);

            if (Invoke != null)
            {
                return;
            }

            try
            {
                var parameter1 = Expression.Parameter(typeof(T1));
                var parameter2 = Expression.Parameter(typeof(T2));
                Invoke = Expression.Lambda<Func<T1, T2, R>>(
                    Expression.Convert(
                        Expression.Add(parameter1, parameter2), 
                        typeof(R)
                    ),
                    parameter1, parameter2
                ).Compile();
            }
            catch (Exception)
            {
                Invoke = Throw.Func<T1, T2, R>;
            }

        }

    }

}
