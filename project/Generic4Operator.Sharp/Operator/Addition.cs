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
            OperatorFactory.TryBind(ref Invoke, (byte a, byte b) => a + b);
            OperatorFactory.TryBind(ref Invoke, (int a, uint b) => a + b);
            OperatorFactory.TryBind(ref Invoke, (int a, float b) => a + b);
            OperatorFactory.TryBind(ref Invoke, (int a, double b) => a + b);
            OperatorFactory.TryBind(ref Invoke, (int a, long b) => a + b);

            OperatorFactory.TryBind(ref Invoke, (bool a, bool b) => a || b);
            OperatorFactory.TryBind(ref Invoke, (string a, string b) => a + b);

            if (Invoke != null)
            {
                return;
            }

            try
            {
                var parameter1 = Expression.Parameter(typeof(T1));
                var parameter2 = Expression.Parameter(typeof(T2));

                Expression left = parameter1;
                Expression right = parameter2;

                var toLift = AdditionTable.Find(typeof(T1), typeof(T2));
                if (toLift != null)
                {
                    left = Expression.Convert(left, toLift);
                    right = Expression.Convert(right, toLift);
                }

                Invoke = Expression.Lambda<Func<T1, T2, R>>(
                    Expression.Convert(
                        Expression.Add(left, right), 
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

    internal static class AdditionTable
    {
        private static readonly Type[][] Values =
        {
            new Type[]{typeof(byte), typeof(byte), typeof(int) },
            new Type[]{typeof(int), typeof(uint), typeof(long) },
            new Type[]{typeof(int), typeof(float), typeof(float) },
            new Type[]{typeof(int), typeof(double), typeof(double) },
            new Type[]{typeof(int), typeof(long), typeof(long) },
        };

        public static Type Find(Type a, Type b)
        {
            foreach (var value in Values)
            {
                if (value[0] == a && value[1] == b || value[0] == b && value[1] == a)
                {
                    return value[2];
                }
            }
            return null;
        }
    }

}
