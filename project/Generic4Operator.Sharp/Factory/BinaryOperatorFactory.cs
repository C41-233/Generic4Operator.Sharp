
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Generic4Operator.Operator;

namespace Generic4Operator.Factory
{
    internal class BinaryOperatorFactory
    {

        private struct Description
        {
            public Type T1;
            public Type ToT1;
            public Type T2;
            public Type ToT2;
            public Type R;
        }

        private readonly string OperatorName;
        private readonly Func<Expression, Expression, Expression> BinaryExpression;

        private readonly List<Description> Primitives = new List<Description>();

        public BinaryOperatorFactory(string operatorName, Func<Expression, Expression, Expression> binaryExpression)
        {
            OperatorName = operatorName;
            BinaryExpression = binaryExpression;
        }

        // ReSharper disable once UnusedParameter.Local
        public void RegisterPrimitive<T1, T2, R>(Func<T1, T2, R> func)
        {
            Primitives.Add(new Description
            {
                T1 = typeof(T1),
                ToT1 = typeof(R),
                T2 = typeof(T2),
                ToT2 = typeof(R),
                R = typeof(R)
            });
        }

        public void RegisterPrimitive<T1, ToT1, T2, ToT2, R>()
        {
            Primitives.Add(new Description
            {
                T1 = typeof(T1),
                ToT1 = typeof(ToT1),
                T2 = typeof(T2),
                ToT2 = typeof(ToT2),
                R = typeof(R)
            });
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
                if (value.T1 == typeof(T1) && value.T2 == typeof(T2) && value.R == typeof(R))
                {
                    return Expression.Lambda<Func<T1, T2, R>>(
                        BinaryExpression(
                            Expression.Convert(Expression.Convert(p1, value.ToT1), value.R),
                            Expression.Convert(Expression.Convert(p2, value.ToT2), value.R)
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
                var c1 = ImplicitCastTable.CreateConvertExpression(p1, value.T1);
                var c2 = ImplicitCastTable.CreateConvertExpression(p2, value.T2);
                if (c1 != null && c2 != null && value.R == typeof(R))
                {
                    return Expression.Lambda<Func<T1, T2, R>>(
                        Expression.Convert(
                            BinaryExpression(
                                Expression.Convert(Expression.Convert(c1, value.ToT1), value.R),
                                Expression.Convert(Expression.Convert(c2, value.ToT2), value.R)
                            ),
                            typeof(R)
                        ),
                        p1, p2
                    ).Compile();
                }
            }

            foreach (var value in Primitives)
            {
                var c1 = ImplicitCastTable.CreateConvertExpression(p1, value.T1);
                var c2 = ImplicitCastTable.CreateConvertExpression(p2, value.T2);
                if (c1 != null && c2 != null)
                {
                    return Expression.Lambda<Func<T1, T2, R>>(
                        Expression.Convert(
                            BinaryExpression(
                                Expression.Convert(Expression.Convert(c1, value.ToT1), value.R),
                                Expression.Convert(Expression.Convert(c2, value.ToT2), value.R)
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
