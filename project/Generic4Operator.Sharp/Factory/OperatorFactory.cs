using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Generic4Operator.Factory
{
    internal static class OperatorFactory
    {

        internal static TDelegate CreateDelegate<TDelegate>(MethodInfo method)
        {
            return (TDelegate)(object)Delegate.CreateDelegate(typeof(TDelegate), method);
        }

        internal static TDelegate CreateDelegate<TDelegate>(string operatorName)
            => (TDelegate) (object) CreateDelegate(typeof(TDelegate), operatorName);

        private static Delegate CreateDelegate(Type delegateType, string operatorName)
        {
            var method = delegateType.GetMethod("Invoke");

            var returnType = method.ReturnType;
            var parameterTypes = method.GetParameters().Select(p => p.ParameterType).ToArray();

            var result = CreateDelegate(delegateType, returnType, operatorName, returnType, parameterTypes);
            if (result != null)
            {
                return result;
            }
            foreach (var parameterType in parameterTypes)
            {
                result = CreateDelegate(delegateType, parameterType, operatorName, returnType, parameterTypes);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }

        private static Delegate CreateDelegate(Type delegateType, Type type, string operatorName, Type returnType, Type[] parameterTypes)
        {
            var method = type.GetSpecialMethods().FirstOrDefault(
                m => m.Name == operatorName
                && m.ReturnType == returnType
                && m.GetParameters().Is(parameterTypes)
            );
            if (method == null)
            {
                return null;
            }
            return Delegate.CreateDelegate(delegateType, method);
        }

        internal static void TryBind<OutT, InT>(ref ChangeDelegate<OutT> result, ChangeDelegate<InT> body)
        {
            if (typeof(OutT) == typeof(InT))
            {
                result = (ChangeDelegate<OutT>)(object)body;
            }
        }

        internal static void TryBind<OutT, InT>(ref Func<OutT> result, Func<InT> body)
        {
            if (typeof(OutT) == typeof(InT))
            {
                result = (Func<OutT>)(object)body;
            }
        }

        internal static void TryBind<OutT, OutR, InT, InR>(ref Func<OutT, OutR> result, Func<InT, InR> body)
        {
            if (typeof(OutT) == typeof(InT)
                && typeof(OutR) == typeof(InR)
            )
            {
                result = (Func<OutT, OutR>)(object)body;
            }
        }

        internal static void TryBind<OutT1, OutT2, OutR, InT1, InT2, InR>(ref Func<OutT1, OutT2, OutR> result, Func<InT1, InT2, InR> body)
        {
            Debug.Assert(!ReferenceEquals(result, body));

            if (typeof(OutT1) == typeof(InT1)
                && typeof(OutT2) == typeof(InT2)
                && typeof(OutR) == typeof(InR)
            )
            {
                result = (Func<OutT1, OutT2, OutR>) (object) body;
            }
        }

    }
}
