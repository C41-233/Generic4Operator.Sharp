using System;
using Generic4Operator.Factory;

// ReSharper disable RedundantAssignment
namespace Generic4Operator.Operator
{

    internal static class PrefixIncrement<T>
    {

        internal static readonly ChangeDelegate<T> Invoke;

        static PrefixIncrement()
        {
            OperatorFactory.TryBind(ref Invoke, (ref byte val) => ++val);
            OperatorFactory.TryBind(ref Invoke, (ref sbyte val) => ++val);
            OperatorFactory.TryBind(ref Invoke, (ref short val) => ++val);
            OperatorFactory.TryBind(ref Invoke, (ref ushort val) => ++val);
            OperatorFactory.TryBind(ref Invoke, (ref int val) => ++val);
            OperatorFactory.TryBind(ref Invoke, (ref uint val) => ++val);
            OperatorFactory.TryBind(ref Invoke, (ref long val) => ++val);
            OperatorFactory.TryBind(ref Invoke, (ref ulong val) => ++val);
            OperatorFactory.TryBind(ref Invoke, (ref float val) => ++val);
            OperatorFactory.TryBind(ref Invoke, (ref double val) => ++val);
            OperatorFactory.TryBind(ref Invoke, (ref bool val) => val = true);
            OperatorFactory.TryBind(ref Invoke, (ref char val) => ++val);

            Invoke = Invoke ?? ((ref T value) =>
            {
                value = Increment<T, T>.Invoke(value);
                return value;
            });
        }

    }

}
