using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Generic4Operator.Factory;

namespace Generic4Operator.Operator
{
    internal static class IndexGet<T, I, R>
    {

        internal static readonly Func<T, I, R> Invoke;

        static IndexGet()
        {
            Invoke = IndexGetFactory.CreateDelegate<Func<T, I, R>>() ?? Throw.Func<T, I, R>;
        }
    }

    internal static class IndexGet<T, I1, I2, R>
    {

        internal static readonly Func<T, I1, I2, R> Invoke;

        static IndexGet()
        {
            Invoke = IndexGetFactory.CreateDelegate<Func<T, I1, I2, R>>() ?? Throw.Func<T, I1, I2, R>;
        }

    }

    internal static class IndexGetFactory
    {
        internal static TDelegate CreateDelegate<TDelegate>()
        {
            var delegateMethod = typeof(TDelegate).GetMethod("Invoke");

            var delegateParameters = delegateMethod.GetParameters();

            var instanceType = delegateParameters[0].ParameterType;
            var returnType = delegateMethod.ReturnType;
            var indexTypes = delegateParameters.Skip(1).Select(p => p.ParameterType).ToArray();

            if (instanceType.IsArray
                && indexTypes.All(t => t == typeof(int))
                && returnType == instanceType.GetElementType())
            {
                var dim = indexTypes.Length;
                var parameterExpressions = new ParameterExpression[dim + 1];
                parameterExpressions[0] = Expression.Parameter(instanceType);
                for (var i = 1; i <= dim; i++)
                {
                    parameterExpressions[i] = Expression.Parameter(typeof(int));
                }
                return Expression.Lambda<TDelegate>(
                    Expression.ArrayIndex(parameterExpressions[0], parameterExpressions.Skip(1)),
                    parameterExpressions
                ).Compile();
            }
            else
            {
                var property = instanceType
                    .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    .FirstOrDefault(
                        p => string.Equals(p.Name, "Item", StringComparison.Ordinal)
                             && p.CanRead
                             && p.GetMethod.ReturnType == returnType
                             && p.GetMethod.GetParameters().Is(indexTypes)
                    );
                if (property == null)
                {
                    return default(TDelegate);
                }

                var parameterExpressions = delegateParameters.Select(p => Expression.Parameter(p.ParameterType)).ToArray();

                return Expression.Lambda<TDelegate>(
                    Expression.MakeIndex(
                        parameterExpressions[0],
                        property,
                        parameterExpressions.Skip(1)
                    ),
                    parameterExpressions
                ).Compile();
            }
        }

    }

}
