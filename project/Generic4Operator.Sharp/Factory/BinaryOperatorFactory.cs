
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Generic4Operator.Operator;

namespace Generic4Operator.Factory
{
    internal class BinaryOperatorFactory
    {
        private readonly string OperatorName;
        private readonly Func<Expression, Expression, Expression> BinaryExpression;

        private readonly List<Tuple<Type, Type, Type>> Primitives = new List<Tuple<Type, Type, Type>>();

        public BinaryOperatorFactory(string operatorName, Func<Expression, Expression, Expression> binaryExpression)
        {
            OperatorName = operatorName;
            BinaryExpression = binaryExpression;
        }

        // ReSharper disable once UnusedParameter.Local
        public void RegisterPrimitive<T1, T2, R>(Func<T1, T2, R> func)
        {
            Primitives.Add(Tuple.Create(typeof(T1), typeof(T2), typeof(R)));
        }

        public Func<T1, T2, R> CreateDelegate<T1, T2, R>()
        {
            var p1 = Expression.Parameter(typeof(T1));
            var p2 = Expression.Parameter(typeof(T2));

            try
            {
                return Expression.Lambda<Func<T1, T2, R>>(
                    BinaryExpression(p1, p2),
                    p1, p2
                ).Compile();
            }
            catch { }

            foreach (var value in Primitives)
            {
                if (value.Item1 == typeof(T1) && value.Item2 == typeof(T2) && value.Item3 == typeof(R))
                {
                    return Expression.Lambda<Func<T1, T2, R>>(
                        BinaryExpression(
                            Expression.Convert(p1, typeof(R)),
                            Expression.Convert(p2, typeof(R))
                        ),
                        p1, p2
                    ).Compile();
                }
            }

            var methodsOfT1 = typeof(T1).GetSpecialMethods().Where(m =>
            {
                if (m.Name != OperatorName)
                {
                    return false;
                }
                var parameters = m.GetParameters();
                if (parameters.Length != 2 || parameters[0].ParameterType != typeof(T1))
                {
                    return false;
                }
                return true;
            }).ToArray();

            foreach (var method in methodsOfT1)
            {
                if (method.GetParameters()[1].ParameterType == typeof(T2) && method.ReturnType == typeof(R))
                {
                    return Expression.Lambda<Func<T1, T2, R>>(
                        BinaryExpression(p1, p2),
                        p1, p2
                    ).Compile();
                }
            }

            var methodsOfT2 = typeof(T2).GetSpecialMethods().Where(m =>
            {
                if (m.Name != OperatorName)
                {
                    return false;
                }
                var parameters = m.GetParameters();
                if (parameters.Length != 2 || parameters[1].ParameterType != typeof(T2))
                {
                    return false;
                }
                return true;
            }).ToArray();

            foreach (var method in methodsOfT2)
            {
                if (method.GetParameters()[0].ParameterType == typeof(T1) && method.ReturnType == typeof(R))
                {
                    return Expression.Lambda<Func<T1, T2, R>>(
                        BinaryExpression(p1, p2),
                        p1, p2
                    ).Compile();
                }
            }

            foreach (var value in Primitives)
            {
                var c1 = ImplicitCastTable.CreateConvertExpression(p1, value.Item1);
                var c2 = ImplicitCastTable.CreateConvertExpression(p2, value.Item2);
                if (c1 != null && c2 != null)
                {
                    return Expression.Lambda<Func<T1, T2, R>>(
                        Expression.Convert(
                            BinaryExpression(
                                Expression.Convert(c1, value.Item3),
                                Expression.Convert(c2, value.Item3)
                            ),
                            typeof(R)
                        ),
                        p1, p2
                    ).Compile();
                }
            }

            foreach (var method in methodsOfT1)
            {
                var c2 = ImplicitCastTable.CreateConvertExpression(p2, method.GetParameters()[1].ParameterType);
                if (c2 != null)
                {
                    return Expression.Lambda<Func<T1, T2, R>>(
                        Expression.Convert(
                            BinaryExpression(p1, c2),
                            typeof(R)
                        ),
                        p1, p2
                    ).Compile();
                }
            }

            foreach (var method in methodsOfT2)
            {
                var c1 = ImplicitCastTable.CreateConvertExpression(p1, method.GetParameters()[0].ParameterType);
                if (c1 != null)
                {
                    return Expression.Lambda<Func<T1, T2, R>>(
                        Expression.Convert(
                            BinaryExpression(c1, p2),
                            typeof(R)
                        ),
                        p1, p2
                    ).Compile();
                }
            }

            return null;
        }

    }
}
