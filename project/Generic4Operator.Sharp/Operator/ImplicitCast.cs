using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Generic4Operator.Factory;

namespace Generic4Operator.Operator
{

    internal static class PrimitiveImplicitCastTable
    {
        
        private static readonly List<Tuple<Type, Type, Delegate>> Values = new List<Tuple<Type, Type, Delegate>>();

        static PrimitiveImplicitCastTable()
        {
            Register<int, long>(x => x);
        }

        private static void Register<T, R>(Func<T, R> func)
        {
            Values.Add(Tuple.Create(typeof(T), typeof(R), (Delegate)func));
        }

        internal static Func<T, R> TryGetImplicitCast<T, R>()
        {
            return (Func<T, R>)TryGetImplicitCast(typeof(T), typeof(R));
        }

        internal static Delegate TryGetImplicitCast(Type t, Type r)
        {
            foreach (var value in Values)
            {
                if (value.Item1 == t && value.Item2 == r)
                {
                    return value.Item3;
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
                //primitive cast
                Invoke = PrimitiveImplicitCastTable.TryGetImplicitCast<T, R>();
                if (Invoke != null)
                {
                    return;
                }

                //object cast
                if (typeof(T).IsSubclassOf(typeof(R)))
                {
                    Invoke = Cast<T, R>.Invoke;
                    return;
                }

                //T -> ?
                var methodsOfT = typeof(T).GetSpecialMethods().Where(m =>
                {
                    if (m.Name != "op_Implicit")
                    {
                        return false;
                    }
                    var paramters = m.GetParameters();
                    if (paramters.Length != 1 || paramters[0].ParameterType != typeof(T))
                    {
                        return false;
                    }
                    return true;
                }).ToArray();

                foreach (var method in methodsOfT)
                {
                    if (method.ReturnType != typeof(R))
                    {
                        continue;
                    }

                    Invoke = (Func<T, R>) Delegate.CreateDelegate(typeof(T), method);
                    return;
                }

                // ? -> R
                var methodsOfR = typeof(R).GetSpecialMethods().Where(m =>
                {
                    if (m.Name != "op_Implicit")
                    {
                        return false;
                    }
                    if (m.ReturnType != typeof(R))
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
                    if (method.GetParameters()[0].ParameterType != typeof(T))
                    {
                        continue;
                    }

                    Invoke = (Func<T, R>)Delegate.CreateDelegate(typeof(R), method);
                    return;
                }

                //implicit indirect cast
                foreach (var method in methodsOfT)
                {
                    var tmp = PrimitiveImplicitCastTable.TryGetImplicitCast(method.ReturnType, typeof(R));
                    if (tmp != null || method.ReturnType.IsSubclassOf(typeof(R)))
                    {
                        var parameter = Expression.Parameter(typeof(T));
                        Invoke = Expression.Lambda<Func<T, R>>(
                            Expression.Convert(
                                Expression.Convert(parameter, method.ReturnType),
                                typeof(R)
                            ),
                            parameter    
                        ).Compile();
                        return;
                    }
                }

                foreach (var method in methodsOfR)
                {
                    var from = method.GetParameters()[0].ParameterType;
                    var tmp = PrimitiveImplicitCastTable.TryGetImplicitCast(typeof(T), from);
                    if (tmp != null || typeof(T).IsSubclassOf(from))
                    {
                        var parameter = Expression.Parameter(typeof(T));
                        Invoke = Expression.Lambda<Func<T, R>>(
                            Expression.Convert(
                                Expression.Convert(parameter, from),
                                typeof(R)
                            ),
                            parameter
                        ).Compile();
                        return;
                    }
                }
            }
            finally
            {
                Supported = Invoke != null;
                Invoke = Invoke ?? Throw.Func<T, R>;
            }
        }

    }
}
