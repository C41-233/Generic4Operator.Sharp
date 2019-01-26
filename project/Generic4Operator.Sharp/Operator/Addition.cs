using System;
using System.Collections.Generic;
using Generic4Operator.Factory;

namespace Generic4Operator.Operator
{

    internal static class AdditionTable
    {
        
        internal static readonly List<Tuple<Type, Type, Type>> Values = new List<Tuple<Type, Type, Type>>();

        static AdditionTable()
        {
            Register((byte a, byte b) => a + b);

            Values.TrimExcess();
        }

        private static void Register<T1, T2, R>(Func<T1, T2, R> func)
        {
        }

    }

    internal static class Addition<T1, T2, R>
    {

        internal static readonly Func<T1, T2, R> Invoke;

        static Addition()
        {
            OperatorFactory.TryBind(ref Invoke, (bool a, bool b) => a || b);
            OperatorFactory.TryBind(ref Invoke, (string a, string b) => a + b);
        }

    }

}
