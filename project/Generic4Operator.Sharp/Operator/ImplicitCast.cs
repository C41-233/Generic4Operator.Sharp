using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Generic4Operator.Factory;

namespace Generic4Operator.Operator
{

    internal static class ImplicitCastTable
    {

        private const string OperatorName = "op_Implicit";

        private static readonly List<Tuple<Type, Type>> Values = new List<Tuple<Type, Type>>();

        static ImplicitCastTable()
        {
            Register<byte, short>(x => x);
            Register<byte, ushort>(x => x);
            Register<byte, int>(x => x);
            Register<byte, uint>(x => x);
            Register<byte, long>(x => x);
            Register<byte, ulong>(x => x);
            Register<byte, float>(x => x);
            Register<byte, double>(x => x);

            Register<int, long>(x => x);
        }

        // ReSharper disable once UnusedParameter.Local
        private static void Register<T, R>(Func<T, R> func)
        {
            Values.Add(Tuple.Create(typeof(T), typeof(R)));
        }

        private static bool CanPrimitiveCast(Type t, Type r)
        {
            foreach (var value in Values)
            {
                if (value.Item1 == t && value.Item2 == r)
                {
                    return true;
                }
            }
            return false;
        }

        internal static Expression CreateConvertExpression(Expression expression, Type to)
        {
            var from = expression.Type;

            //self cast
            if (from == to)
            {
                return expression;
            }

            //primitive cast
            if (CanPrimitiveCast(from, to))
            {
                return Expression.Convert(expression, to);
            }

            //object cast
            if (from.IsSubclassOf(to))
            {
                return Expression.Convert(expression, to);
            }

            //T -> ?
            var methodsOfT = from.GetSpecialMethods().Where(m =>
            {
                if (m.Name != OperatorName)
                {
                    return false;
                }
                var paramters = m.GetParameters();
                if (paramters.Length != 1 || paramters[0].ParameterType != from)
                {
                    return false;
                }
                return true;
            }).ToArray();

            foreach (var method in methodsOfT)
            {
                if (method.ReturnType != to)
                {
                    continue;
                }

                return Expression.Convert(expression, to, method);
            }

            // ? -> R
            var methodsOfR = to.GetSpecialMethods().Where(m =>
            {
                if (m.Name != OperatorName)
                {
                    return false;
                }
                if (m.ReturnType != to)
                {
                    return false;
                }

                var paramters = m.GetParameters();
                if (paramters.Length != 1)
                {
                    return false;
                }

                return true;
            }).ToArray();

            foreach (var method in methodsOfR)
            {
                if (method.GetParameters()[0].ParameterType != from)
                {
                    continue;
                }

                return Expression.Convert(expression, to, method);
            }

            //implicit indirect cast
            foreach (var method in methodsOfT)
            {
                if (CanPrimitiveCast(method.ReturnType, to) || method.ReturnType.IsSubclassOf(to))
                {
                    return Expression.Convert(
                        Expression.Convert(expression, method.ReturnType),
                        to
                    );
                }
            }

            foreach (var method in methodsOfR)
            {
                var tmp = method.GetParameters()[0].ParameterType;
                if (CanPrimitiveCast(from, tmp) || from.IsSubclassOf(tmp))
                {
                    return Expression.Convert(
                        Expression.Convert(expression, tmp),
                        to
                    );
                }
            }

            return null;
        }

    }

    internal static class ImplicitCast<T, R>
    {
        internal static readonly Func<T, R> Invoke;

        internal static readonly bool Supported;

        static ImplicitCast()
        {
            try
            {
                var p = Expression.Parameter(typeof(T));
                var expression = ImplicitCastTable.CreateConvertExpression(p, typeof(R));
                if (expression == null)
                {
                    return;
                }
                Invoke = Expression.Lambda<Func<T, R>>(
                    expression,
                    p
                ).Compile();
            }
            finally
            {
                Supported = Invoke != null;
                Invoke = Invoke ?? Throw.Func<T, R>;
            }
        }

    }
}
