using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Generic4Operator.Factory;

namespace Generic4Operator.Operator
{
    internal static class IndexSet<T, I, E>
    {

        internal static readonly Action<T, I, E> Invoke;

        static IndexSet()
        {
            Invoke = IndexSetFactory.CreateDelegate<Action<T, I, E>>() ?? Throw.Action;
        }

    }

    internal static class IndexSet<T, I1, I2, E>
    {

        internal static readonly Action<T, I1, I2, E> Invoke;

        static IndexSet()
        {
            Invoke = IndexSetFactory.CreateDelegate<Action<T, I1, I2, E>>() ?? Throw.Action;
        }

    }

    internal static class IndexSetFactory
    {

        internal static TDelegate CreateDelegate<TDelegate>()
        {
            var delegateMethod = typeof(TDelegate).GetMethod("Invoke");

            var paramters = delegateMethod.GetParameters();

            var instanceType = paramters[0].ParameterType;
            var parameterTypes = paramters.Skip(1).Select(p => p.ParameterType).ToArray();

            var property = instanceType
                .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(
                    p => string.Equals(p.Name, "Item", StringComparison.Ordinal)
                    && p.CanWrite
                    && p.SetMethod.GetParameters().Is(parameterTypes)
                );
            if (property == null)
            {
                return default(TDelegate);
            }

            var parameterExpressions = paramters.Select(p => Expression.Parameter(p.ParameterType)).ToArray();

            return Expression.Lambda<TDelegate>(
                Expression.Assign(
                    Expression.MakeIndex(
                        parameterExpressions[0],
                        property,
                        parameterExpressions.Skip(1).Take(parameterExpressions.Length - 2)
                    ),
                    parameterExpressions[parameterExpressions.Length - 1]
                ),
                parameterExpressions
            ).Compile();
        }

    }

}
