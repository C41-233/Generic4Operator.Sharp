using Generic4Operator.Operator;

namespace Generic4Operator
{
    public static class Ops
    {

        public static R Add<T1, T2, R>(T1 left, T2 right) 
            => Addition<T1, T2, R>.Invoke(left, right);

        public static T Add<T>(T left, T right) 
            => Addition<T, T, T>.Invoke(left, right);

        public static R Subtract<T1, T2, R>(T1 left, T2 right)
            => Subtraction<T1, T2, R>.Invoke(left, right);

        public static T Subtract<T>(T left, T right)
            => Subtraction<T, T, T>.Invoke(left, right);

        public static R Multiply<T1, T2, R>(T1 left, T2 right)
            => Operator.Multiply<T1, T2, R>.Invoke(left, right);

        public static T Multiply<T>(T left, T right)
            => Operator.Multiply<T, T, T>.Invoke(left, right);

        public static R Index<T, I, R>(T value, I index)
            => IndexGet<T, I, R>.Invoke(value, index);

        public static R Index<T, I1, I2, R>(T value, I1 index1, I2 index2)
            => IndexGet<T, I1, I2, R>.Invoke(value, index1, index2);

        public static void Index<T, I, E>(T value, I index, E element)
            => IndexSet<T, I, E>.Invoke(value, index, element);

        public static void Index<T, I1, I2, E>(T value, I1 index1, I2 index2, E element)
            => IndexSet<T, I1, I2, E>.Invoke(value, index1, index2, element);

        public static R Increase<T, R>(T value)
            => Increment<T, R>.Invoke(value);

        public static T Increase<T>(T value)
            => Increment<T, T>.Invoke(value);

        public static T IncreaseAndGet<T>(ref T value)
            => PrefixIncrement<T>.Invoke(ref value);

        public static T IncreaseAndGetOriginal<T>(ref T value)
            => PostfixIncrement<T>.Invoke(ref value);

        public static T Decrease<T>(T value)
            => Decrement<T, T>.Invoke(value);

        public static R Decrease<T, R>(T value)
            => Decrement<T, R>.Invoke(value);

        public static T DecreaseAndGet<T>(ref T value)
            => PrefixDecrement<T>.Invoke(ref value);

        public static T DecreaseAndGetOriginal<T>(ref T value)
            => PostfixDecrement<T>.Invoke(ref value);

        public static T ZeroValue<T>() 
            => Zero<T>.Invoke();

        public static T Positive<T>(T value) 
            => UnaryPlus<T, T>.Invoke(value);

        public static R Positive<T, R>(T value) 
            => UnaryPlus<T, R>.Invoke(value);

        public static R Negative<T, R>(T value) 
            => UnaryNegation<T, R>.Invoke(value);

        public static T Negative<T>(T value) 
            => UnaryNegation<T, T>.Invoke(value);

        public static R LogicalNot<T, R>(T value)
            => Operator.LogicalNot<T, R>.Invoke(value);

        public static bool Not<T>(T value)
            => Operator.LogicalNot<T, bool>.Invoke(value);

        public static T LogicalNot<T>(T value)
            => Operator.LogicalNot<T, T>.Invoke(value);

        public static R Complement<T, R>(T value)
            => OnesComplement<T, R>.Invoke(value);

        public static T Complement<T>(T value)
            => OnesComplement<T, T>.Invoke(value);

    }

}
