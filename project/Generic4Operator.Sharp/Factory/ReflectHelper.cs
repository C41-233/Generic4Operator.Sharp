using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Generic4Operator.Factory
{
    internal static class ReflectHelper
    {
        internal static bool Is(this ParameterInfo[] parameters, params Type[] others)
        {
            if (parameters.Length != others.Length)
            {
                return false;
            }
            var len = parameters.Length;
            for (var i = 0; i < len; i++)
            {
                if (parameters[i].ParameterType != others[i])
                {
                    return false;
                }
            }
            return true;
        }

        internal static IEnumerable<MethodInfo> GetSpecialMethods(this Type type)
            => type.GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.IsSpecialName);
    }
}
