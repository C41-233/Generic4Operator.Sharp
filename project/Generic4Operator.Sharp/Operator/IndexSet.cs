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
            var delegateParameters = typeof(TDelegate).GetMethod("Invoke").GetParameters();

            var instanceType = delegateParameters[0].ParameterType;
            var parameterTypes = delegateParameters.Skip(1).Select(p => p.ParameterType).ToArray();

            var indexCount = parameterTypes.Length - 1;
            var passType = parameterTypes[parameterTypes.Length - 1];

            if (instanceType.IsArray 
                && parameterTypes.Take(indexCount).All(t => t == typeof(int)) 
                && passType == instanceType.GetElementType()
            )
            {
                var parameterExpressions = delegateParameters.Select(p => Expression.Parameter(p.ParameterType)).ToArray();

                return Expression.Lambda<TDelegate>(
                    Expression.Assign(
                        Expression.ArrayAccess(
                            parameterExpressions[0], 
                            parameterExpressions.Skip(1).Take(indexCount)
                        ),
                        parameterExpressions[parameterExpressions.Length - 1]
                    ),
                    parameterExpressions
                ).Compile();
            }
            else
            {
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

                var parameterExpressions = delegateParameters.Select(p => Expression.Parameter(p.ParameterType)).ToArray();

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

}
